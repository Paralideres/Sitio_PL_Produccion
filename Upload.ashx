<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;

public class Upload : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            
            
            //Dim strArchivo As String = File_U.Value.ToString()
                
            string savepath = "";
            string tempPath = "";
            tempPath = System.Configuration.ConfigurationManager.AppSettings["DDescargasFiles"];


            //string strPath ="";
            
            //string strCaracter = "/";
            
            //strPath = context.Server.MapPath(".").ToString();
            
            //strPath = strPath +  "files";
                
            
                

            //postedFile.SaveAs(context.Server.MapPath(".") + '\files\' &  + postedFile.FileName.);
            //tempPath = context.Server.MapPath(".") + tempPath;
            //Server.MapPath(".\") & tempPath & "\" & postedFileg
            //File_U.PostedFile.SaveAs(Server.MapPath(".\") & "files\" & oColaboracion.strPic.ToString) 
            savepath = context.Server.MapPath(tempPath);
            string filename = postedFile.FileName;
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);

            //postedFile.SaveAs(Server.MapPath('.\') + 'files\' + @"\" + filename);
            postedFile.SaveAs(savepath + @"\" + filename);
            context.Response.Write(tempPath + "/" + filename);
            context.Response.StatusCode = 200;
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}