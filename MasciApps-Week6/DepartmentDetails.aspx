<%@ Page Title="Department Details" Language="C#" MasterPageFile="~/Interior.Master" AutoEventWireup="true" CodeBehind="DepartmentDetails.aspx.cs" Inherits="MasciApps_Week6.DepartmentDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="interior-page" id="departmentdetails-page">
        <div class="container custom-form">

            <div class="input-container">
                <asp:TextBox runat="server" CssClass="input" ID="NameTextBox" Placeholder="Department Name" required="true"></asp:TextBox>
            </div>
            <div class="input-container">
                <asp:TextBox runat="server" CssClass="input" ID="BudgetTextBox" Placeholder="Budget" required="true"></asp:TextBox>
            </div>
            <div class="submit">
                <asp:Button runat="server" CssClass="cancel" ID="DepartmentCancelButton" Text="Cancel" UseSubmitBehaviour="false"
                    CausesValidation="false" OnClick="DepartmentCancelButton_Click" />
                <asp:Button runat="server" CssClass="save" ID="DepartmentSaveButton" Text="Save" UseSubmitBehaviour="true"
                    CausesValidation="true" OnClick="DepartmentSaveButton_Click" />
            </div>

        </div>
    </div>

</asp:Content>
