<%@ Page Title="Students" Language="C#" MasterPageFile="~/Interior.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="MasciApps_Week6.Students" %>

<asp:Content ID="StudentsPageContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="interior-page" id="students-page">
        <div class="container">

            <div class="button button1">
                <a href="StudentDetails.aspx"><i class="fa fa-plus-circle"></i> Add Student</a>
            </div>
            <div class="students-container">
                <div class="pagesize">
                    <label>Records Per Page: </label>
                    <asp:DropDownList runat="server" ID="StudentsDropDownList" AutoPostBack="true" CssClass="button button1"
                        OnSelectedIndexChanged="StudentsDropDownList_SelectedIndexChanged" >
                        <asp:ListItem Text="Max" Value="5000"></asp:ListItem>
                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:GridView runat="server" ID="StudentsGridView" DataKeyNames="StudentID" AutoGenerateColumns="False"
                    OnRowDeleting="StudentsGridView_RowDeleting" OnRowDataBound="StudentsGridView_RowDataBound"                    
                    AllowPaging="true" PageSize="5000" OnPageIndexChanging="StudentsGridView_PageIndexChanging" 
                    AllowSorting="true" OnSorting="StudentsGridView_Sorting" >
                    <Columns>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" Visible="true" SortExpression="StudentID" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" Visible="true" SortExpression="LastName" />
                        <asp:BoundField DataField="FirstMidName" HeaderText="First Name" Visible="true" SortExpression="FirstMidName" />
                        <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" Visible="true" SortExpression="EnrollmentDate"
                            DataFormatString="{0:MMM dd, yyyy}" />
                        <asp:CommandField HeaderText="<i class='fa fa-trash-o'></i>" DeleteText="<i class='fa fa-trash-o'></i>" ShowDeleteButton="true"
                            ButtonType="Link" ControlStyle-CssClass="" />
                        <asp:HyperLinkField HeaderText="<i class='fa fa-pencil'></i>" Text="<i class='fa fa-pencil'></i>" NavigateUrl="~/StudentDetails.aspx"
                            ItemStyle-CssClass="" DataNavigateUrlFields="StudentID" DataNavigateUrlFormatString="StudentDetails.aspx?StudentID={0}" />
                    </Columns>
                </asp:GridView>
            </div>

        </div>  
    </div>

</asp:Content>
