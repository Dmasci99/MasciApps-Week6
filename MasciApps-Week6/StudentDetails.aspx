<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/Interior.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="MasciApps_Week6.StudentDetails" %>

<asp:Content ID="StudentDetailsPageContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="interior-page" id="studentdetails-page">
        <div class="container custom-form">

            <div class="input-container">
                <asp:TextBox runat="server" CssClass="input" ID="LastNameTextBox" Placeholder="Last Name" required="true"></asp:TextBox>
            </div>
            <div class="input-container">
                <asp:TextBox runat="server" CssClass="input" ID="FirstNameTextBox" Placeholder="First Name" required="true"></asp:TextBox>
            </div>
            <div class="input-container">
                <asp:TextBox runat="server" CssClass="input" ID="EnrollmentDateTextBox" Placeholder="Enrollment Date" TextMode="Date" required="true"></asp:TextBox>
            </div>
            <div class="submit">
                <asp:Button runat="server" CssClass="cancel" ID="ContactCancelButton" Text="Cancel" UseSubmitBehaviour="false"
                    CausesValidation="false" OnClick="ContactCancelButton_Click"  />
                <asp:Button runat="server" CssClass="save" ID="ContactSaveButton" Text="Save" UseSubmitBehaviour="true"
                    CausesValidation="true" OnClick="ContactSaveButton_Click" />
            </div>

        </div>
    </div>

</asp:Content>
