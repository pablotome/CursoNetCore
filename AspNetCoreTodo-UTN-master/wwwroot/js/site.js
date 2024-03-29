﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var clientes;
$(window).on("load", function(){
    clientes = [
        {nombre: "Lucio", apellido: "Lema"},
        {nombre: "Juan", apellido: "Perez"}
    ];
    mostrarClientes();
    //traerClientes();
});

function traerClientes(){
    $.getJSON( "js/clientes.json", function() {
        console.log( "success" );
      }).done(function(data){
        clientes = data;
        mostrarClientes();
      });
}

function mostrarClientes(){
    for(var i=0; i<clientes.length;i++)
    {

    }
    clientes.forEach(c => {
        $("#listaCliente").append("<li>"+c.apellido+"</li>");
        $("#tabla").append("<tr><td>"+c.apellido+"</td></tr>");
    });
}

$(document).ready(function(){
    $('.datepicker').datepicker({ format: 'yyyy-mm-dd' });

    $(".done-checkbox").on('click', function(e){
        markCompleted(e.target);
    });
});

function markCompleted(checkbox)
{
    checkbox.disabled = true;
    var row = checkbox.closest('tr');
    $(row).addClass('done');
    var form = checkbox.closest('form');
    form.submit();
}