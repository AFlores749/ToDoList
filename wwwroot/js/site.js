// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var IdOpenModal = 0;
var url = "https://localhost:44307/Task/Delete?";

$(function () {

    $('.openDeleteModal').click(function () {
        IdOpenModal = $(this).data('id');
    });

    $('#ModalDelete').click(function () {
        fetch(url + $.param({ id: IdOpenModal }), {
            method: 'POST'
        }).then((response) => {
            $('#tasks-table > tbody > tr[data-id=' + IdOpenModal + ']').remove();
            if ($('#tasks-table > tbody > tr').length == 0) {
                $('#tasks-table').append('<tr><td colspan="5" class="text-center">No Tasks Saved</td></tr');
            }
            $('#deleteModal').modal('hide');
        });
    });

});