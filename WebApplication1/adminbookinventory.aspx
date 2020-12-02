<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="WebApplication1.adminbookinventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" height="150px" width="100px" src="imgs/books1.png" />
                                </center>
                            </div>
                        </div>            
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:FileUpload onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                           <div class="col-md-3">
                                 <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group"">
                                    <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder="Book ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button4" runat="server" Text="Go" OnClick="Button4_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-9">
                                 <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="Book Name" ></asp:TextBox>
                                </div>
                            </div>

                             
                        </div>

                        <div class="row">
                           
                            <div class="col-md-4">
                                 <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Greek" Value="Greek" />
                                        <asp:ListItem Text="Spanish" Value="Spanish" />
                                        <asp:ListItem Text="French" Value="French" />
                                        <asp:ListItem Text="German" Value="German" />
                                        <asp:ListItem Text="Russian" Value="Russian" />
                                    </asp:DropDownList>
                                </div>

                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2" />
                                       
                                    </asp:DropDownList>
                                </div>

                            </div>

                            

                             <div class="col-md-4">
                                 <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                        <asp:ListItem Text="a1" Value="a1" />
                                        <asp:ListItem Text="a2" Value="a2" />
                                       
                                    </asp:DropDownList>
                                </div>

                                <label>Publish Date</label>
                                <div class="form-group">
                                   
                                  <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>

                                    </asp:DropDownList>
                                </div>
                            </div>
                             
                            <div class="col-md-4">
                                 <label>Genre</label>
                                <div class="form-group">
                                      <asp:ListBox class="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">
                                          <asp:ListItem Text="Adventure" Value="Adventure" />
                                          <asp:ListItem Text="Drama" Value="Drama" />
                                          <asp:ListItem Text="Horror" Value="Horror" />
                                          <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                          <asp:ListItem Text="Wellness" Value="Wellness" />

                                      </asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                           
                            <div class="col-md-4">
                                 <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Edition"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>Book Cost</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Book Cost" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox11" runat="server" placeholder="Pages" TextMode="Number" ></asp:TextBox>
                                </div>
                            </div>
                             
                        </div>

                        <div class="row">
                           
                            <div class="col-md-4">
                                 <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>Curent Stock</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder="Current Stock" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                 <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Issued Books" TextMode="Number" ReadOnly="true" ></asp:TextBox>
                                </div>
                            </div>
                             
                        </div>

                        <div class="row">
                    

                            <div class="col-md-12">
                                 <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                             
                        </div>

                        <div class="row">

                            <div class="col-4">
                            <asp:Button class="btn btn-lg btn-block btn-success" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                            </div>

                            <div class="col-4">
                            <asp:Button class="btn btn-lg btn-block btn-warning" ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
                            </div>

                            <div class="col-4">
                            <asp:Button class="btn btn-lg btn-block btn-danger" ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <a href="homepage.aspx"><< Back to Home</a> <br /><br />

            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Inventory List</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id" >
                                        
                                        <ItemStyle Font-Bold="True" />
                                        </asp:BoundField>
                                        
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-10">
                                                            <div class="row">
                                                                <div class="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Author -
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                    &nbsp;| Genre -
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>'></asp:Label>
                                                                    &nbsp;| Language -
                                                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Publisher -
                                                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    &nbsp;| Publish Date
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    &nbsp;| Pages -
                                                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    &nbsp;| Edition -
                                                                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Cost -
                                                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock -
                                                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    &nbsp;| Available Stock -
                                                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-12">

                                                                    Description -
                                                                    <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("book_description") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Image class="img-fluid p-2" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView> 
                            </div>
                        </div>
                        
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
