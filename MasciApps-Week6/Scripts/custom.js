/**
* Author : Daniel Masci - 200299037
* Class : Enterprise Computing
* Semester : 4
* Professor : Tom Tsiliopolous
* Purpose : Assignment 1 - ASP.NET Portfolio
* Website Name : DanMasci.azurewebsites.net
*/

/**
* The following file is the "MASTER" Javascript file that encompasses JQuery. It includes
* all my custom jQuery functionality that is used across my portfolio.
*/

jQuery(document).ready(function ($) {

    /*************************************************
	*				Departments Delete
	*************************************************/
    $('#departments-page .deleteDept').click(function () {
        return confirm("Are you sure you want to delete this record?");
    });

});