<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="WebApplication1.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <img src="imgs/home-bg.jpg" class="img-fluid"/>
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Our Features</h2>
                    <p><b>Our 3 Primary Features -</b></p>
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                    <img width="150px" src="imgs/digital-inventory.png"/>
                    <h4>Digital Book Inventory</h4>
                    <p class="text-justify"> As an Admin, you have the ability to view books, users and manipulate them by issuing books. You can monitor the stock going up or down in the inventory. </p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                    <img width="150px" src="imgs/search-online.png"/>
                    <h4>Search Books</h4>
                    <p class="text-justify"> As a User or an Admin, you may search the inventory based on any criteria (title, genre etc.) in the View Books page. </p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                    <img width="150px" src="imgs/defaulters-list.png"/>
                    <h4>View and Manage Your Profile</h4>
                    <p class="text-justify"> As a User, you can view your profile and manage your credentials, as well as view how many books you have been issued with and the date which you must return them. </p>
                    </center>
                </div>
            </div>
        </div>
    </section>

    <section>
        <img src="imgs/in-homepage-banner.jpg" class="img-fluid"/>
    </section>

     <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Our Process</h2>
                    <p><b>We have a simple 3 step process</b></p>
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                    <img width="150px" src="imgs/sign-up.png"/>
                    <h4>Sign Up</h4>
                    <p class="text-justify"> Signup or Login if you already are a user </p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                    <img width="150px" src="imgs/search-online.png"/>
                    <h4>Search Books</h4>
                    <p class="text-justify"> Find the book you would like to borrow and read in our inventory </p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                    <img width="150px" src="imgs/library.png"/>
                    <h4>Visit Us</h4>
                    <p class="text-justify"> Visit us at our Library at "Address, State, Country goes here" </p>
                    </center>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
