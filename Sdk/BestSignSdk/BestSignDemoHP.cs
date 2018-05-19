using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DiiL.Sdk.BestSignSdk
{
    public class BestSignDemoHP
    {
        private readonly string host = "https://openapi.bestsign.info/openapi/v2";
        private readonly string developerId = "1979554829764133474";
        private readonly string pem = "MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAKkb3eluVdU"
            + "0rg0emMMKcEyYRo51aCxBsir+8rGwp1NUXNR75abSThgD1ByD5SdoYZjfaz9VZ0mowOkmGqgPqqVvLBacHbph"
            + "9mRBNesMdXcyUOp9x1VhVaE7PHyaLBYqPaWcm1hfFXtMx+/ytk3pt3xNkKUBsQjYuH6sGeL6nWFTAgMBAAECg"
            + "YBGBUPdY9ImdambxQ97stbM4EBWvEZmDM24/9d9u6eM2WGWmbZ9XJb5Wpx5MiOwLYg7xEaj8rjRxw4Ze62N6O6+4"
            + "8HtNEm4Rcek7aBVq0Y9AKZrg+/xvAiDNzb2kBGPKJP5/zbM+LJqEvKE/valkDYMlw4vcEsDEBXC/SDA7lLgAQJBAOp"
            + "ihAEy365SOeQs/Gb8mRe5/o4Qk65pJUqpRDkas+tnUgpmzUuiiqLfoIOdsjBRkLj4CCc56OYdCOcbj+9hhmsCQQC4t"
            + "EfUXIwQn4lB0MAL2bH2ofoHAIOy+mDFwxca9BuoxRg4Yus7TcgpCLAsuN4TGZKzvWGyqysp65T8zqUDzTq5AkBo"
            + "vNlMR9WY6nmgM1IfG2W2KpFMHrA/0hCuCnHIKtyXpzYMG+BFmj7lhZUO+5sy6GAJqBzMmp4upm7iB3kMecI9AkBQF"
            + "SJbqfC0uGcrmRXbTX0CwUIFzSxM6pAQzsBy2Eoxx5rzv7fcE6JoYDL6gQEQaPMZaVA1xk9FsrX7UqFrX41JAkEAnJ9Rz"
            + "FoiHpJhb/vbRnbyrjWPJKrTDcnz7Ea+qBAsVP9D97MZMn+tVLpncDuQye1U2tDDsoOpyV3k1eCtb4iEAQ==";


        public static BestSignDemoHP GetInstance()
        {
            return new BestSignDemoHP();
        }

        #region 通用接口
        public ArrayList Reg(string account, string name, string userType, string mail, string mobile, object credential, string applyCert)
        {
            string path = "/user/reg";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            data.Add("name", name);
            data.Add("userType", userType);
            data.Add("mail", mail);
            data.Add("mobile", mobile);
            data.Add("credential", credential);
            data.Add("applyCert", applyCert);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList GetSignerStatus(string contractId)
        {
            string path = "/contract/getSignerStatus";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("contractId", contractId);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList GetCert(string account)
        {
            string path = "/user/getCert";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList GetApplyCertStatus(string account, string taskId)
        {
            string path = "/user/async/applyCert/status/";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            data.Add("taskId", taskId);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        // 获取模版变量
        public ArrayList GetTemplateVars(string tid, string isRetrieveAllVars)
        {
            string path = "/template/getTemplateVars/";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("tid", tid);
            data.Add("isRetrieveAllVars", isRetrieveAllVars);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList GetCertInfo(string account, string certId)
        {
            string path = "/user/cert/info/";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            data.Add("certId", certId);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList GetPersonalCredential(string account)
        {
            string path = "/user/getPersonalCredential";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList GetEnterpriseCredential(string account)
        {
            string path = "/user/getEnterpriseCredential";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList SignatureImageCreate(string account, string text, string fontName, string fontSize, string fontColor)
        {
            string path = "/storage/signatureImage/user/create";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            data.Add("text", text);
            data.Add("fontName", fontName);
            data.Add("fontSize", fontSize);
            data.Add("fontColor", fontColor);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList UploadSignatureImage(string account, string imageData, string imageName)
        {
            string path = "/signatureImage/user/upload";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            data.Add("imageData", imageData);
            data.Add("imageName", imageName);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public string DownloadSignatureImage(string account, string imageName)
        {
            string path = "/signatureImage/user/download";
            string url = host + GetUrlByRsa(account, imageName, path);

            url = url + "&account=" + account + "&imageName=" + HttpUtility.UrlEncode(imageName, Encoding.UTF8);
            return url;
        }

        public ArrayList DocUpload(string account, string fdata, string fmd5, string ftype, string fname, string fpages)
        {
            string path = "/storage/upload";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            data.Add("fdata", fdata);
            data.Add("fmd5", fmd5);
            data.Add("ftype", ftype);
            data.Add("fname", fname);
            data.Add("fpages", fpages);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList AddPdfElements(string account, string fid, object elements)
        {
            string path = "/storage/addPDFElements";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            data.Add("fid", fid);
            data.Add("elements", elements);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList FileConvert(string account, string fid, string ftype)
        {
            string path = "/storage/convert";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            data.Add("fid", fid);
            data.Add("ftype", ftype);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public string FileDownload(string fid)
        {
            string path = "/storage/download";
            string url = host + GetUrlByRsa(fid, path);
            url = url + "&fid=" + HttpUtility.UrlEncode(fid, Encoding.UTF8);
            return url;
        }

        public string ContractDownload(string contractId)
        {
            string path = "/storage/contract/download";
            string url = host + GetUrlByRsaContractDownload(contractId, path);
            url = url + "&contractId=" + HttpUtility.UrlEncode(contractId, Encoding.UTF8);
            return url;
        }

        public ArrayList ContractCreate(string account, string fmd5, string ftype, string fname, string fpages, string fdata, string title, string expireTime, string description)
        {
            string path = "/storage/contract/upload";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            data.Add("fmd5", fmd5);
            data.Add("ftype", ftype);
            data.Add("fname", fname);
            data.Add("fpages", fpages);
            data.Add("fdata", fdata);
            data.Add("title", title);
            data.Add("expireTime", expireTime);
            data.Add("description", description);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList AutoSign(string contractId, string signer, object signaturePositions, string signatureImageName, string signatureImageData)
        {
            string path = "/storage/contract/sign/cert";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("contractId", contractId);
            data.Add("signer", signer);
            data.Add("signaturePositions", signaturePositions);
            data.Add("signatureImageName", signatureImageName);
            data.Add("signatureImageData", signatureImageData);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList ContractSend(string contractId, string signer, object signaturePositions, string isAllowChangeSignaturePosition, string returnUrl, string vcodeMobile, string isDrawSignatureImage, string expireTime, string version, string sid)
        {
            string path = "/contract/send";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("contractId", contractId);
            data.Add("signer", signer);
            data.Add("signaturePositions", signaturePositions);
            data.Add("isAllowChangeSignaturePosition", isAllowChangeSignaturePosition);
            data.Add("returnUrl", returnUrl);
            data.Add("vcodeMobile", vcodeMobile);
            data.Add("isDrawSignatureImage", isDrawSignatureImage);
            data.Add("expireTime", expireTime);
            data.Add("version", version);
            data.Add("sid", sid);

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList GetPreviewURL(string contractId, string account, string dpi, string expireTime)
        {
            string path = "/contract/getPreviewURL";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("contractId", contractId);
            data.Add("account", account);
            data.Add("dpi", dpi);
            data.Add("expireTime", expireTime);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList Lock(string contractId)
        {
            string path = "/storage/contract/lock";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("contractId", contractId);

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList GetDownloadURLs(string contractId)
        {
            string path = "/contract/getDownloadURLs";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("contractId", contractId);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList CatalogCreate(string senderAccount, string expireTime, string catalogName, string description)
        {
            string path = "/catalog/create";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("senderAccount", senderAccount);
            data.Add("expireTime", expireTime);
            data.Add("catalogName", catalogName);
            data.Add("description", description);
            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList UploadContract(string senderAccount, string catalogName, string fid, string title, string fmd5, string fname, string ftype, string fpages, string fdata, string expireTime, string description)
        {
            string path = "/catalog/uploadContract";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("senderAccount", senderAccount);
            data.Add("catalogName", catalogName);
            data.Add("fid", fid);
            data.Add("title", title);
            data.Add("fmd5", fmd5);
            data.Add("fname", fname);
            data.Add("ftype", ftype);
            data.Add("fpages", fpages);
            data.Add("fdata", fdata);
            data.Add("expireTime", expireTime);
            data.Add("description", description);

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList ContractSend(string contractId, string bridegroomCellphone, List<object> signaturePositions, string v1, string v2, object p, string v3, string unix, object customerId)
        {
            throw new NotImplementedException();
        }

        public ArrayList ContractList(string catalogName)
        {
            string path = "/catalog/getContracts";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("catalogName", catalogName);

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList CatalogSend(string catalogName, string signerAccount, string returnUrl, string vcodeMobile, object contractParams)
        {
            string path = "/catalog/send";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("catalogName", catalogName);
            data.Add("signerAccount", signerAccount);
            data.Add("returnUrl", returnUrl);
            data.Add("vcodeMobile", vcodeMobile);
            data.Add("contractParams", contractParams);

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList GetCatalogPreviewURL(string catalogName, string signerAccount, string dpi, string expireTime)
        {
            string path = "/catalog/getPreviewURL";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("catalogName", catalogName);
            data.Add("signerAccount", signerAccount);
            data.Add("dpi", dpi);
            data.Add("expireTime", expireTime);

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList CatalogLock(string catalogName)
        {
            string path = "/catalog/lock";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("catalogName", catalogName);

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList TemplateCreate(string account, string tid, object templateValues)
        {
            string path = "/template/createPdf";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            data.Add("tid", tid);
            data.Add("templateValues", templateValues);

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList SendByTemplate(string contractId, string signer, string tid, string varNames)
        {
            string path = "/contract/sendByTemplate";
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                { "contractId", contractId },
                { "signer", signer },
                { "dpi", "120" },
                { "expireTime", "0" },
                { "tid", tid },
                { "varNames", varNames },
                { "isAllowChangeSignaturePosition", "1" },
                { "returnUrl", "" },
                { "vcodeMobile", "" },
                { "isDrawSignatureImage", "1" },
                { "signatureImageName", "default" },
                { "pushUrl", "" },
                { "version", "2" },
            };

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList CreateByTemplate(string account, string tid, string templateToken, string title, string description, string expireTime)
        {
            string path = "/contract/createByTemplate";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("account", account);
            data.Add("tid", tid);
            data.Add("templateToken", templateToken);
            data.Add("title", title);
            data.Add("description", description);
            data.Add("expireTime", expireTime);

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList SignTemplate(string contractId, string tid, object vars, string loginIp, string loginTime, string signIp)
        {
            string path = "/contract/sign/template";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("contractId", contractId);
            data.Add("tid", tid);
            data.Add("vars", vars);
            data.Add("loginIp", loginIp);
            data.Add("loginTime", loginTime);
            data.Add("signIp", signIp);

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }

        public ArrayList TeamSign(string contractId, string signImage, string certId, string nameList, string nameListHash, string hashAlgorithm, object signaturePositions)
        {
            string path = "/storage/contract/team/sign";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("contractId", contractId);
            data.Add("signImage", signImage);
            data.Add("certId", certId);
            data.Add("nameList", nameList);
            data.Add("nameListHash", nameListHash);
            data.Add("hashAlgorithm", hashAlgorithm);
            data.Add("signaturePositions", signaturePositions);

            string url = host + GetUrlByRsa(data, path);
            string dataString = JsonConvert.SerializeObject(data);
            var result = HttpSender.HttpSendUtil.PostData(dataString, url, null);
            return result;
        }
        #endregion


        #region 签名sign计算
        private string GetUrlByRsa(Dictionary<string, object> data, string path) //POST方法
        {
            string randomStr = Utils.rand(1000, 9999) + "";
            string unix = ((System.DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
            string rtick = unix + randomStr;
            string dataMD5 = "";
            if (null != data)
            {
                string jsonData = JsonConvert.SerializeObject(data);
                dataMD5 = CreateMD5Hash(jsonData);
            }
            string signString = "developerId=" + developerId + "rtick=" + rtick + "signType=rsa/openapi/v2" + path + "/" + dataMD5;
            string signData = Convert.ToBase64String(RsaSign(Encoding.UTF8.GetBytes(signString), pem));
            signData = HttpUtility.UrlEncode(signData, Encoding.UTF8);
            path = path + "/?developerId=" + developerId + "&rtick=" + rtick + "&sign=" + signData + "&signType=rsa";
            return path;
        }

        private string GetUrlByRsa(string account, string imageName, string path) //GET方法：签名图片下载
        {
            string randomStr = Utils.rand(1000, 9999) + "";
            string unix = ((System.DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
            string rtick = unix + randomStr;
            string signString = "account=" + account + "developerId=" + developerId + "imageName=" + imageName + "rtick=" + rtick + "signType=rsa/openapi/v2" + path + "/";
            string signData = Convert.ToBase64String(RsaSign(Encoding.UTF8.GetBytes(signString), pem));
            signData = HttpUtility.UrlEncode(signData, Encoding.UTF8);
            path = path + "/?developerId=" + developerId + "&rtick=" + rtick + "&sign=" + signData + "&signType=rsa";
            return path;
        }

        private string GetUrlByRsa(string fid, string path) //GET方法：文件下载
        {
            string randomStr = Utils.rand(1000, 9999) + "";
            string unix = ((System.DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
            string rtick = unix + randomStr;
            string signString = "developerId=" + developerId + "fid=" + fid + "rtick=" + rtick + "signType=rsa/openapi/v2" + path + "/";
            string signData = Convert.ToBase64String(RsaSign(Encoding.UTF8.GetBytes(signString), pem));
            signData = HttpUtility.UrlEncode(signData, Encoding.UTF8);
            path = path + "/?developerId=" + developerId + "&rtick=" + rtick + "&sign=" + signData + "&signType=rsa";
            return path;
        }

        private string GetUrlByRsaContractDownload(string contractId, string path) //GET方法：合同下载
        {
            string randomStr = Utils.rand(1000, 9999) + "";
            string unix = ((System.DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
            string rtick = unix + randomStr;
            string signString = "contractId=" + contractId + "developerId=" + developerId + "rtick=" + rtick + "signType=rsa/openapi/v2" + path + "/";
            string signData = Convert.ToBase64String(RsaSign(Encoding.UTF8.GetBytes(signString), pem));
            signData = HttpUtility.UrlEncode(signData, Encoding.UTF8);
            path = path + "/?developerId=" + developerId + "&rtick=" + rtick + "&sign=" + signData + "&signType=rsa";
            return path;
        }

        public byte[] RsaSign(byte[] data, string privateKey)
        {
            RSACryptoServiceProvider rsa = DecodePemPrivateKey(privateKey);
            SHA1 sh = new SHA1CryptoServiceProvider();
            return rsa.SignData(data, sh);
        }

        public string CreateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
        #endregion

        #region 内部方法
        private static RSACryptoServiceProvider DecodePemPrivateKey(String pemstr)
        {
            byte[] pkcs8privatekey;
            pkcs8privatekey = Convert.FromBase64String(pemstr);
            if (pkcs8privatekey != null)
            {
                RSACryptoServiceProvider rsa = DecodePrivateKeyInfo(pkcs8privatekey);
                return rsa;
            }
            else
                return null;
        }

        private static RSACryptoServiceProvider DecodePrivateKeyInfo(byte[] pkcs8)
        {
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] seq = new byte[15];

            MemoryStream mem = new MemoryStream(pkcs8);
            int lenstream = (int)mem.Length;
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading    
            byte bt = 0;
            ushort twobytes = 0;

            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)    //data read as little endian order (actual data order for Sequence is 30 81)    
                    binr.ReadByte();    //advance 1 byte    
                else if (twobytes == 0x8230)
                    binr.ReadInt16();    //advance 2 bytes    
                else
                    return null;

                bt = binr.ReadByte();
                if (bt != 0x02)
                    return null;

                twobytes = binr.ReadUInt16();

                if (twobytes != 0x0001)
                    return null;

                seq = binr.ReadBytes(15);        //read the Sequence OID    
                if (!CompareBytearrays(seq, SeqOID))    //make sure Sequence for OID is correct    
                    return null;

                bt = binr.ReadByte();
                if (bt != 0x04)    //expect an Octet string    
                    return null;

                bt = binr.ReadByte();        //read next byte, or next 2 bytes is  0x81 or 0x82; otherwise bt is the byte count    
                if (bt == 0x81)
                    binr.ReadByte();
                else
                    if (bt == 0x82)
                    binr.ReadUInt16();
                //------ at this stage, the remaining sequence should be the RSA private key    

                byte[] rsaprivkey = binr.ReadBytes((int)(lenstream - mem.Position));
                RSACryptoServiceProvider rsacsp = DecodeRSAPrivateKey(rsaprivkey);
                return rsacsp;
            }

            catch (Exception)
            {
                return null;
            }

            finally { binr.Close(); }

        }

        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }
            return true;
        }

        private static RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
        {
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;

            // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------    
            MemoryStream mem = new MemoryStream(privkey);
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading    
            byte bt = 0;
            ushort twobytes = 0;
            int elems = 0;
            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)    //data read as little endian order (actual data order for Sequence is 30 81)    
                    binr.ReadByte();    //advance 1 byte    
                else if (twobytes == 0x8230)
                    binr.ReadInt16();    //advance 2 bytes    
                else
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102)    //version number    
                    return null;
                bt = binr.ReadByte();
                if (bt != 0x00)
                    return null;


                //------  all private key components are Integer sequences ----    
                elems = GetIntegerSize(binr);
                MODULUS = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                E = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                D = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                P = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                Q = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DP = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DQ = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                IQ = binr.ReadBytes(elems);

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----    
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSAParameters RSAparams = new RSAParameters();
                RSAparams.Modulus = MODULUS;
                RSAparams.Exponent = E;
                RSAparams.D = D;
                RSAparams.P = P;
                RSAparams.Q = Q;
                RSAparams.DP = DP;
                RSAparams.DQ = DQ;
                RSAparams.InverseQ = IQ;
                RSA.ImportParameters(RSAparams);
                return RSA;
            }
            catch (Exception)
            {
                return null;
            }
            finally { binr.Close(); }
        }

        private static int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)        //expect integer    
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();    // data size in next byte    
            else
                if (bt == 0x82)
            {
                highbyte = binr.ReadByte();    // data size in next 2 bytes    
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;        // we already have the data size    
            }



            while (binr.ReadByte() == 0x00)
            {    //remove high order zeros in data    
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);        //last ReadByte wasn't a removed zero, so back up a byte    
            return count;
        }

        //private static string encrypt(byte[] data, string publicKey, string input_charset)
        //{
        //    RSACryptoServiceProvider rsa = DecodePemPublicKey(publicKey);
        //    SHA1 sh = new SHA1CryptoServiceProvider();
        //    byte[] result = rsa.Encrypt(data, false);

        //    return Convert.ToBase64String(result);
        //}

        //private static string decrypt(byte[] data, string privateKey, string input_charset)
        //{
        //    string result = "";
        //    RSACryptoServiceProvider rsa = DecodePemPrivateKey(privateKey);
        //    SHA1 sh = new SHA1CryptoServiceProvider();
        //    byte[] source = rsa.Decrypt(data, false);
        //    char[] asciiChars = new char[Encoding.GetEncoding(input_charset).GetCharCount(source, 0, source.Length)];
        //    Encoding.GetEncoding(input_charset).GetChars(source, 0, source.Length, asciiChars, 0);
        //    result = new string(asciiChars);
        //    //result = ASCIIEncoding.ASCII.GetString(source);    
        //    return result;
        //}

        //private static RSACryptoServiceProvider DecodePemPublicKey(String pemstr)
        //{
        //    byte[] pkcs8publickkey;
        //    pkcs8publickkey = Convert.FromBase64String(pemstr);
        //    if (pkcs8publickkey != null)
        //    {
        //        RSACryptoServiceProvider rsa = DecodeRSAPublicKey(pkcs8publickkey);
        //        return rsa;
        //    }
        //    else
        //        return null;
        //}

        //private static RSACryptoServiceProvider DecodeRSAPublicKey(byte[] publickey)
        //{
        //    // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"    
        //    byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
        //    byte[] seq = new byte[15];
        //    // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------    
        //    MemoryStream mem = new MemoryStream(publickey);
        //    BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading    
        //    byte bt = 0;
        //    ushort twobytes = 0;

        //    try
        //    {

        //        twobytes = binr.ReadUInt16();
        //        if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)    
        //            binr.ReadByte();    //advance 1 byte    
        //        else if (twobytes == 0x8230)
        //            binr.ReadInt16();   //advance 2 bytes    
        //        else
        //            return null;

        //        seq = binr.ReadBytes(15);       //read the Sequence OID    
        //        if (!CompareBytearrays(seq, SeqOID))    //make sure Sequence for OID is correct    
        //            return null;

        //        twobytes = binr.ReadUInt16();
        //        if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)    
        //            binr.ReadByte();    //advance 1 byte    
        //        else if (twobytes == 0x8203)
        //            binr.ReadInt16();   //advance 2 bytes    
        //        else
        //            return null;

        //        bt = binr.ReadByte();
        //        if (bt != 0x00)     //expect null byte next    
        //            return null;

        //        twobytes = binr.ReadUInt16();
        //        if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)    
        //            binr.ReadByte();    //advance 1 byte    
        //        else if (twobytes == 0x8230)
        //            binr.ReadInt16();   //advance 2 bytes    
        //        else
        //            return null;

        //        twobytes = binr.ReadUInt16();
        //        byte lowbyte = 0x00;
        //        byte highbyte = 0x00;

        //        if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)    
        //            lowbyte = binr.ReadByte();  // read next bytes which is bytes in modulus    
        //        else if (twobytes == 0x8202)
        //        {
        //            highbyte = binr.ReadByte(); //advance 2 bytes    
        //            lowbyte = binr.ReadByte();
        //        }
        //        else
        //            return null;
        //        byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order    
        //        int modsize = BitConverter.ToInt32(modint, 0);

        //        byte firstbyte = binr.ReadByte();
        //        binr.BaseStream.Seek(-1, SeekOrigin.Current);

        //        if (firstbyte == 0x00)
        //        {   //if first byte (highest order) of modulus is zero, don't include it    
        //            binr.ReadByte();    //skip this null byte    
        //            modsize -= 1;   //reduce modulus buffer size by 1    
        //        }

        //        byte[] modulus = binr.ReadBytes(modsize);   //read the modulus bytes    

        //        if (binr.ReadByte() != 0x02)            //expect an Integer for the exponent data    
        //            return null;
        //        int expbytes = (int)binr.ReadByte();        // should only need one byte for actual exponent data (for all useful values)    
        //        byte[] exponent = binr.ReadBytes(expbytes);

        //        // ------- create RSACryptoServiceProvider instance and initialize with public key -----    
        //        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        //        RSAParameters RSAKeyInfo = new RSAParameters();
        //        RSAKeyInfo.Modulus = modulus;
        //        RSAKeyInfo.Exponent = exponent;
        //        RSA.ImportParameters(RSAKeyInfo);
        //        return RSA;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //    finally { binr.Close(); }
        //}
        #endregion

    }
}
