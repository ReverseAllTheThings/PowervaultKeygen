using System.IO;
using System.Security.Cryptography;

namespace DellPowerVaultFeatureKeygen
{
    /// <summary>
    /// Defined in SMclient.jar at devmgr.v1125api15.symbol.FeatureKey
    /// </summary>
    public class Feature
    {
        public int KeyVersion { get; set; } = 1;

        public byte[] UniqueId { get; set; } = new byte[16];

        public int SupportedFeatureBundleId { get; set; }

        public Capability Capability { get; set; }

        public int Limit { get; set; }

        public int Duration { get; set; }

        public byte[] FeatureEnableId { get; set; } = new byte[16];

        // defined in firmware's utlCreateFeatureKey function
        public byte[] Digest
        {
            get
            {
                byte[] digest = null;
                byte[] salt = { 0x82, 0x64, 0x09, 0x17, 0xB3, 0x5D, 0x7A, 0x9F };

                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    sha1.Initialize();

                    sha1.TransformBlock(salt, 0, salt.Length, salt, 0);
                    sha1.TransformBlock(FeatureEnableId, 0, FeatureEnableId.Length, FeatureEnableId, 0);

                    if (KeyVersion > 1)
                    {
                        sha1.TransformBlock(UniqueId, 0, UniqueId.Length, UniqueId, 0);

                        byte[] supportedFeatureBundleId = Utility.ReverseEndian(SupportedFeatureBundleId);
                        sha1.TransformBlock(supportedFeatureBundleId, 0, supportedFeatureBundleId.Length, supportedFeatureBundleId, 0);

                        byte[] capability = Utility.ReverseEndian((int)Capability);
                        sha1.TransformBlock(capability, 0, capability.Length, capability, 0);

                        byte[] limit = Utility.ReverseEndian(Limit);
                        sha1.TransformBlock(limit, 0, limit.Length, limit, 0);

                        byte[] duration = Utility.ReverseEndian(Duration);
                        sha1.TransformFinalBlock(duration, 0, duration.Length);
                    }
                    else
                    {
                        byte[] capability = Utility.ReverseEndian((int)Capability);
                        sha1.TransformFinalBlock(capability, 0, capability.Length);
                    }

                    digest = sha1.Hash;

                    sha1.Initialize();

                    sha1.TransformBlock(FeatureEnableId, 0, FeatureEnableId.Length, FeatureEnableId, 0);
                    sha1.TransformFinalBlock(digest, 0, digest.Length);

                    digest = sha1.Hash;
                }

                return digest;
            }
        }

        public Feature()
        {

        }

        public Feature(byte[] featureEnableId, Capability capability)
        {
            FeatureEnableId = featureEnableId;
            Capability = capability;
        }

        public Feature(byte[] featureEnableId, Capability capability, int limit)
        {
            FeatureEnableId = featureEnableId;
            Capability = capability;
            KeyVersion = 2; // assumed if specifying a limit
            Limit = limit;
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(Utility.ReverseEndian(KeyVersion));
            writer.Write(UniqueId);
            writer.Write(Utility.ReverseEndian(SupportedFeatureBundleId));
            writer.Write(Utility.ReverseEndian((int)Capability));
            writer.Write(Utility.ReverseEndian(Limit));
            writer.Write(Utility.ReverseEndian(Duration));
            writer.Write(FeatureEnableId);
            writer.Write(Digest);
        }
    }
}
