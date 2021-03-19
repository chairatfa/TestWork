
$( document ).ready(function() {    
    LoadData();
});

$(document).on("click", "#btnInsertSave", function() {
    // alert("OK");
    // $('#myModal').modal('hide');
    // var formData = new FormData($('#product_view_insert')[0]);   
    $.ajax({
        url: '../MainAction/Ins_User',
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(getIDs()),
      
        success: function (result) {
             console.log(result);
             var obj =  jQuery.parseJSON(result)
             if(obj.ResponseCode=="1"){
                alert("บันทึกข้อมูลเรียบร้อย");
                $('#myModal_Ins').modal('hide');
                ClearData();
                LoadData();
             }else{
                var input = obj.ResponseMessage.toString();
                var fields = input.split('-');                
                var name = fields[0];
                var description = fields[1];
                alert(description);
                document.getElementById(name).focus();
             }
           
        }
    });

});
$(document).on("click", "#btnEditSave", function() {

    // alert("OK");
    // $('#myModal').modal('hide');
    // var formData = new FormData($('#product_view_insert')[0]);   
    $.ajax({
        url: '../MainAction/Edit_User',
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(getIDsEdit()),
      
        success: function (result) {
             console.log(result);
             var obj =  jQuery.parseJSON(result)
             if(obj.ResponseCode=="1"){
                alert("บันทึกข้อมูลเรียบร้อย");
                $('#myModal_Edit').modal('hide');
                ClearData();
                LoadData();
             }else{
                var input = obj.ResponseMessage.toString();
                var fields = input.split('-');                
                var name = fields[0];
                var description = fields[1];
                alert(description);
                document.getElementById(name+"_e").focus();
             }
           
        }
    });

});

$(document).on("click", "#btnDltSave", function() {

    // alert("OK");
    // $('#myModal').modal('hide');
    // var formData = new FormData($('#product_view_insert')[0]);   
    $.ajax({
        url: '../MainAction/Dlt_User',
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(getIDsDlt()),
      
        success: function (result) {
             console.log(result);
             var obj =  jQuery.parseJSON(result)
             if(obj.ResponseCode=="1"){
                alert("ยืนยันข้อมูลเรียบร้อย");                
                $('#myModal_Delete').modal('hide');
                ClearData();
                LoadData();
             }else{
                var input = obj.ResponseMessage.toString();
                var fields = input.split('-');                
                var name = fields[0];
                var description = fields[1];
                alert(description);
               
             }
           
        }
    });

});

function getIDs() {
    var data =   
    { 
     "UserCode": document.getElementById("UserCode").value,
     "FirstName": document.getElementById("FirstName").value,
     "LastName": document.getElementById("LastName").value,
     "Fullname": "",
     "TelNumber": document.getElementById("TelNumber").value,
     "Email": document.getElementById("Email").value,
     "Status": ""
     };
    return data;
}
function getIDsEdit() {
    var data =   
    { 
     "UserCode": document.getElementById("UserCode_e").value,
     "FirstName": document.getElementById("FirstName_e").value,
     "LastName": document.getElementById("LastName_e").value,
     "Fullname": "",
     "TelNumber": document.getElementById("TelNumber_e").value,
     "Email": document.getElementById("Email_e").value,
     "Status": ""
     };
    return data;
}
function getIDsDlt() {
    var data =   
    { 
     "UserCode": document.getElementById("UserCode_d").value,
     "FirstName": document.getElementById("FirstName_d").value,
     "LastName": document.getElementById("LastName_d").value,
     "Fullname": "",
     "TelNumber": document.getElementById("TelNumber_d").value,
     "Email": document.getElementById("Email_d").value,
     "Status": ""
     };
    return data;
}
function ClearData() {
    // form insert
     document.getElementById("UserCode").value="";
     document.getElementById("FirstName").value="";
     document.getElementById("LastName").value="";   
     document.getElementById("TelNumber").value="";
     document.getElementById("Email").value="";

     // form Edit
     document.getElementById("UserCode_e").value="";
     document.getElementById("UserCode_e1").value="";               
     document.getElementById("FirstName_e").value="";
     document.getElementById("LastName_e").value="";  
     document.getElementById("TelNumber_e").value="";
     document.getElementById("Email_e").value="";

     // form Delete
     document.getElementById("UserCode_d").value="";
     document.getElementById("UserCode_d1").value="";               
     document.getElementById("FirstName_d").value="";
     document.getElementById("LastName_d").value="";  
     document.getElementById("TelNumber_d").value="";
     document.getElementById("Email_d").value="";
    
    
}

function LoadData() {
    var table = $('#example1').DataTable();
    table.destroy();

    $.ajax({
        url: '../MainAction/load_User',
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: { "usercode":"" },
      
        success: function (result) {
             
             var obj =  jQuery.parseJSON(result)
             
             console.log(obj);
          
             if(obj.length>0){

                var table =$('#example1').DataTable({
                    data: obj,                 
                    "columns": [
                      
                        {
                            data: { UserCode: 'UserCode' },
                            render: function(data) {
                                return '<td style=" cursor:hand;" > '
                                +'<i class="fa fa-trash icondelete " style="font-size:160%;" onClick="OpenDlt(\'' + data.UserCode+ '\')" title="ลบข้อมูล" data-toggle="modal" data-target="#myModal_Delete"></i>'
                                +'&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'
                                +'<i class="fa fa-address-card iconedit" style="font-size:160%;" onClick="OpenEdit(\'' + data.UserCode+ '\')" title="แก้ไข" data-toggle="modal" data-target="#myModal_Edit"></i>'                                                              
                                +'</td>';
                             }
                        },
                        {
                            data: { UserCode: 'UserCode' },
                            render: function(data) {
                                return '<td>' +data.UserCode + '</td>';
                             }
                        },
                        {
                            data: { Fullname: 'Fullname' },
                            render: function(data) {
                                return '<td>' +data.Fullname + '</td>';
                             }
                        },
                        {
                            data: { TelNumber: 'TelNumber' },
                            render: function(data) {
                                return '<td>' +data.TelNumber + '</td>';
                             }
                        },
                        {
                            data: { Email: 'Email' },
                            render: function(data) {
                                return '<td>' +data.Email + '</td>';
                             }
                        }                      
                       
                    ],
                });
               
           
              }
           
        }
    });
   
}
function OpenEdit(usercode){
    // alert(usercode);
    $.ajax({
        url: '../MainAction/load_User',
        type: "POST",
        // contentType: 'application/json; charset=utf-8',
        data: { "usercode":usercode },
      
        success: function (result) {
            var obj =  jQuery.parseJSON(result)
             
            console.log(obj);            
            if(obj.length>0){
               var mark1 = "";
               for (var i = 0; i < obj.length; i++) {
                document.getElementById("UserCode_e").value=obj[i].UserCode;
                document.getElementById("UserCode_e1").value=obj[i].UserCode;                
                document.getElementById("FirstName_e").value=obj[i].FirstName;
                document.getElementById("LastName_e").value=obj[i].LastName;   
                document.getElementById("TelNumber_e").value=obj[i].TelNumber;
                document.getElementById("Email_e").value=obj[i].Email;
               }
            }
           
        }
    });
}

function OpenDlt(usercode){
    // alert(usercode);
    $.ajax({
        url: '../MainAction/load_User',
        type: "POST",
        // contentType: 'application/json; charset=utf-8',
        data: { "usercode":usercode },
      
        success: function (result) {
            var obj =  jQuery.parseJSON(result)
             
            console.log(obj);            
            if(obj.length>0){
               var mark1 = "";
               for (var i = 0; i < obj.length; i++) {
                document.getElementById("UserCode_d").value=obj[i].UserCode;
                document.getElementById("UserCode_d1").value=obj[i].UserCode;                
                document.getElementById("FirstName_d").value=obj[i].FirstName;
                document.getElementById("LastName_d").value=obj[i].LastName;   
                document.getElementById("TelNumber_d").value=obj[i].TelNumber;
                document.getElementById("Email_d").value=obj[i].Email;
               }
            }
           
        }
    });
}
