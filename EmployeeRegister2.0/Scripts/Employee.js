


var modalBg = document.querySelector('#popupDelete');
var modalBgEdit = document.querySelector('#popupEdit');
function ConfirmDelete(id) {
    $('#hiddenEmployeeId').val(id);
    modalBg.classList.add('popup-active');
}

function DeleteEmp() {
    var EmpID = $('#hiddenEmployeeId').val();
     
    
    $.ajax({
        type: "POST",
        url: "/Employee/DeleteEmp",
        data: { id: EmpID },  

        error: function () {
            alert("ERRO");
        },
        success: function () {
            modalBg.classList.add('popup-disable');    
            alert("Funcionário deletado com sucesso.");
        }
    })
   
}

function EditEmployee(idEmp) {
    $('#hiddenEmployeeId').val(idEmp);
    

    if (idEmp != null) {
        $.ajax({    
            type: 'GET',
            url: '/Employee/SearchEmployee',  // SEARCH EMPLOYEE
            data: { id: idEmp },
            success: function (employee) {
                $('#id').val(employee.EmployeeId);
                $('#nome').val(employee.EmployeeFirstName);
                $('#sobrenome').val(employee.EmployeeLastName);
                $('#email').val(employee.EmployeeEmail);
                $('#departmentId').val(employee.DepartmentId);
             
                modalBgEdit.classList.add('popup-active');
            },
            error: function () {
                alert("Error");
            }

        })
    }
    else {
        alert("Erro - Id vazio")
    }
   
}


function Update() {
    var empData = $('#EmployeeData').serialize();
    $.ajax({
        type: "POST",
        url:'/Employee/UpdateEmployee',
        data: empData,
        success: function(){
            alert("Funcionário atualizado com sucesso.");
        },
        error: function () {
            alert("Erro ao atualizar funcionário!");
        }

    })

}




  
