<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="WebApplication1.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>User Registration</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                 <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Full Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Your full name is required!" ControlToValidate="TextBox3" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <label>Date of Birth</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Your birth date is required!" ControlToValidate="TextBox4" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                 <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator5" runat="server" ErrorMessage="A phone number is required!" ControlToValidate="TextBox5" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please, enter your Email address!" ControlToValidate="TextBox6" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                 <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                            <asp:ListItem Text="Select" Value="select" />
                                            <asp:ListItem Text="Alabama" Value="AL" />

                                            <asp:ListItem Text="Alaska" Value="AK" />

                                            <asp:ListItem Text="Arizona" Value="AZ" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="City"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Your Pin Code required!" ControlToValidate="TextBox7" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Full Address</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please enter a full address!" ControlToValidate="TextBox8" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            
                            <div class="col">
                               <center> <span class="badge badge-pill badge-info">Login Credentials</span></center>
                            </div>
                            
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                 <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="User ID"></asp:TextBox>
                                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a valid User ID!" ControlToValidate="TextBox1" ValidationGroup="SignUp"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-6">
                                 <label>Password</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator class="text-danger" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please enter a Password!" ControlToValidate="TextBox9" ValidationGroup="SignUp" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator class="text-danger" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Password must be at least 8 characters long and have a number" validationexpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ControlToValidate="TextBox9" ValidationGroup="SignUp" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Sign Up" OnClick="Button1_Click" ValidationGroup="SignUp" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <a href="homepage.aspx"><< Back to Home</a> <br /><br />

            </div>
        </div>
    </div>


</asp:Content>
