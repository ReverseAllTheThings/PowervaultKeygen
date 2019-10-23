### Background

Picking up used enterprise equipment online can be a great way to fill out a homelab environment on a budget.
Unfortunately, Dell won't issue licensing for devices out of warranty, and warranties for 10-year-old end-of-life equipment are either difficult/impossible to obtain or extremely cost-prohibitive for educational use purposes.
Warranties also become rather useless in most lab environments if disposable or where uptime isn't critical to operations.

Benchmarking an all-flash MD3220 array with fully-redundant cabling and HBA adapters was a bit disappointing due to the arbitrary performance limitations put in place by Dell from lack of a "High Performance Tier" license.
Since the proper channels won't provide any assistance with this due to reasons mentioned above there was little choice left but to pop open the hood and take a look at what's inside to assess feasibility and hopefully breathe some new life back into this aging hardware.

### Research

##### Sample Gathering

A sample license key can be obtained through [md-storage.com](http://md-storage.com) using [Dell's instructional video](https://www.youtube.com/watch?v=ax3Bgtq0NSQ) for reference.
Additional license keys for comparison purposes were obtained via various support logs publicly posted online containing the pairs of service tags and feature enable identifiers necessary for fulfillment.
Viewing the licenses in a hex editor shows each feature key likely has a 20-byte hash associated with it; SHA1 being the primary candidate.
Unfortunately none of the hashes matched up with standard SHA1 results across the various blocks of data so further digging was required.

##### Firmware Analysis

The latest firmware can be found [directly](https://downloads.dell.com/FOLDER04304840M/1/PowerVault_MD32_MD36_Series_Firmware_08_20_24_60.zip) on Dell's website.
Viewing the file in a hex editor shows a custom package file format with a header and chunk(s) of data afterwards.
Running [offzip](https://aluigi.altervista.org/mytoolz/offzip.zip) against it luckily enough extracts the content within.
Disassembling the extracted binaries with ghidra, searching for the SHA1 initialization constants, and then backtracking through callers led to a `utlCreateFeatureKey` function within the largest binary.


##### Client Software Analysis

The MDSM client management software can be obtained [directly](https://downloads.dell.com/FOLDER04066625M/1/DELL_MDSS_Consolidated_RDVD_6_5_0_1.iso) from Dell's site and then extracted through several layers using 7-zip until the target SMClient.jar is found.
Fortunately, the client software exists unobfuscated in java form which can be easily [decompiled](http://java-decompiler.github.io/).
It turns out the `utlCreateFeatureKey` parameters are in the order they exist in the SMClient `FeatureKey` class with the addition of sizes being serialized into the mix preceeding arrays.

### Discovery

The Dell (NetApp/LSI) PowerVault storage array lineup "sign" their multi-thousand-dollar premium feature license keys using a salted SHA1 hash of various key components.
Hash algorithms are not a sufficient means to protect information and should be used for error-checking purposes only.
Ideally, the firmware packages and licenses would both be RSA-signed and encrypted to prevent lazy analysis/modification attempts such as this.
The accompanying project is a proof of concept I've used to validate these findings and generate license keys which match the sample licenses.

### Disclaimer

This is my own original research/work that has been obtained/created through legal means via reverse-engineering publicly available information related to a legacy device I own and contains no copyright-infringing material of any kind.
Everything above can be done without agreeing to any TOS/EULA etc.
I am in no way condoning piracy, particularly in a business setting, but do wish to bring attention to Dell's lack of consideration towards educational use on older generation equipment.
What others do with this information is not my responsibility.