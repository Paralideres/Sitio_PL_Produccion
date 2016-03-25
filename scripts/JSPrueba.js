var FilterDom = {
    File: "#fileToUpload",
    Subir: "#btnSubir"
};

$(window).load(
    function() 
    {

        $(FilterDom.File).fileUpload
       // $("#fileToUpload").fileUpload
        ({
            'uploader': 'scripts/uploader.swf', 
            'cancelImg': 'images/cancel.png',
            'buttonText': 'Browse Files',
            'script': 'Upload.ashx',
            'folder': 'files',
            'fileDesc': 'Image Files',
            //'fileExt': '*.jpg;*.jpeg;*.gif;*.png;*.doc;*.docx;*.pdf',
            'fileExt': '*.doc;*.docx;*.pdf;*.ppt;*.pptx',
            'multi': false,
            'auto': false
        });
    
    }
);    

$(document).ready(function() {

      $(FilterDom.Subir).click(function() {

   var fileInput = $(FilterDom.File)[0];
//   var myFSO = new ActiveXObject("Scripting.FileSystemObject");
 //var thefile = myFSO.getFile(fileInput);
      //var size = thefile.size;
      
      //var imgbytes = fileInput.files[0].size; // Size returned in bytes.
      //var imgbytes = fileInput.files[0].fileSize; // Size returned in bytes.
      //var imgkbytes = Math.round(parseInt(imgbytes) / 1024);
     // alert(imgkbytes + ' KB');
    
    
        $(FilterDom.File).fileUploadStart();
    });

});