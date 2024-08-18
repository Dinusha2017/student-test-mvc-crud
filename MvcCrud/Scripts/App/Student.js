const jsToast = new JSFrame();

$(document).ready(function () {

    $(".deleteStudentLink").on("click", function () {
        let studentId = $(this).attr('data-studentId');
        $("#deleteStudentId").html(studentId);
    });

});

function deleteStudent() {
    let studentId = $("#deleteStudentId").html();

    $.ajax({
        url: "/Student/DeleteStudent",
        data: { studentId: studentId },
        type: "DELETE",
        success: function (data) {
            $("#deleteStudentModal").modal("hide");
            jsToast.showToast(
                {
                    width: 260,
                    height: 100,
                    duration: 3000, //Duration(millis)
                    align: 'top', // alignment from 'top'/'center'/'bottom'(default)
                    style: {
                        borderRadius: '2px',
                        backgroundColor: '#bb2d3b',
                    },
                    html: '<span style="color:white;">Student with ID: ' + studentId + ' was deleted successfully!</span>',
                    closeButton: false
                });

            setTimeout(function () {
                window.location.href = "Index";
            }, 3000);
        },
        error: function (error) {
            console.log(`Error: ${error}`);
        }
    });
}