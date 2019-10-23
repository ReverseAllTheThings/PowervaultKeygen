using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DellPowerVaultFeatureKeygen
{
    /// <summary>
    /// Defined in SMclient.jar at devmgr.v1125api15.sam.scriptengine.FeatureKeyDecoder
    /// </summary>
    public class License
    {
        private readonly byte[] _preamble = { 0xAC, 0xED, 0x00, 0x05, 0x74 };
        private const int _fileVersion = 2;
        private const string _versionTwoSignature = "FEATURE KEYS";

        public List<Feature> Features { get; } = new List<Feature>();

        public void Save(string filename)
        {
            using (FileStream stream = File.Create(filename))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(_preamble);
                writer.Write(Utility.ReverseEndian((short)_versionTwoSignature.Length));
                writer.Write(Encoding.ASCII.GetBytes(_versionTwoSignature));
                writer.Write(Utility.ReverseEndian(_fileVersion));
                writer.Write(Utility.ReverseEndian(Features.Count));

                foreach (Feature feature in Features)
                {
                    feature.Save(writer);
                }
            }
        }
    }
}
