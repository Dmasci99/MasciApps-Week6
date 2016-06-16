<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Interior.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="MasciApps_Week6.Departments" %>

<asp:Content ID="DepartmentsPageContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="interior-page" id="departments-page">
        <div class="container">

            <div class="button button1">
                <a href="DepartmentDetails.aspx"><i class="fa fa-plus-circle"></i> Add</a>
            </div>
            
            <div class="departments-container">
                <asp:GridView runat="server" ID="DepartmentsGridView" DataKeyNames="DepartmentID" AutoGenerateColumns="false"
                    OnRowDataBound="DepartmentsGridView_RowDataBound" OnRowDeleting="DepartmentsGridView_RowDeleting"
                    AllowSorting="true" OnSorting="DepartmentsGridView_Sorting" >
                    <Columns>
                        <asp:BoundField runat="server" DataField="DepartmentID" HeaderText="ID" SortExpression="DepartmentID" />
                        <asp:BoundField runat="server" DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField runat="server" DataField="Budget" HeaderText="Budget" SortExpression="Budget" DataFormatString="{0:C}" />
                        <asp:HyperLinkField runat="server" Text="<i class='fa fa-pencil'></i>" HeaderText="<i class='fa fa-pencil'></i>" 
                            DataNavigateUrlFields="DepartmentID" DataNavigateUrlFormatString="DepartmentDetails.aspx?DepartmentID={0}"
                            NavigateUrl="~/DepartmentDetails.aspx" />                        
                        <asp:CommandField runat="server" DeleteText="<i class='fa fa-trash-o deleteDept'></i>" HeaderText="<i class='fa fa-trash-o'></i>" 
                            ShowDeleteButton="true" ButtonType="Link" />    
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
