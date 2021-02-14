<%@ Page Title="Quiz | Chadior Beauty" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="IngredientSelection.aspx.cs" Inherits="WebApp.IngredientSelection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <script src="https://cdn.datatables.net/1.10.23/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.23/js/dataTables.bootstrap4.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('#example').DataTable({
                scrollY: 400,
                scrollX: true,
                scrollCollapse: true,
                paging: false,
            });

            var max_limit = 3;
            

            $(".chcktbl1").each(function (index) {
                
                this.checked = (".chcktbl1:input:checkbox" < max_limit);
            }).change(function () {
                if ($(".chcktbl1:input:checkbox:checked").length > max_limit) {
                    this.checked = false;
                }
            });

            
            $("#btn_Submit").click(function () {
                var values = $('input[type="checkbox"].chcktbl1:checked').map(function () {
                    return $(this).attr("data-id");
                }).toArray();


                if (values.length !== 3) {
                    alert("You need to select 3 Ingredients!");
                    window.location.reload();
                }
                else
                {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "IngredientSelection.aspx/getData",
                        data: JSON.stringify({ ingredients: values }),
                        datatype: "JSON",
                        
                        success: function (result) {
                            window.location = "<%= ResolveUrl("~/Shopping Cart/ProductFormulation.aspx") %>";
                        },
                        error: function (errorThrown) {
                            alert(errorThrown);
                        }
                    });
                }
                
            });
            
            
        });  

    </script> 
    
    <style>
        table.dataTable thead th, table.dataTable thead td {
            border-bottom: 0px;
        }

        .dataTables_wrapper .dataTables_filter input {
            background-color: white;
        }

        .dataTables_wrapper.no-footer .dataTables_scrollBody{
            border-bottom: 0px;
        }

        .table-hover tbody tr:hover{
            color: #772de6;
            background-color: #f1d0f1;
        }

        table{
            background-color: white;
            border: 0px;
        }

    </style>

    <br />
    <br />
    <br />
    <br />
    

    <div class="container">
        <div class="row justify-content-center">
            <h3>Ingredient Selection</h3>
        </div>
        <div class="row justify-content-center">
            <h6>Please Select 3 Ingredients</h6>
        </div>
        
        <br />

        <!-- GRIDVIEW ASYNC PANEL -->
        <div class="row justify-content-center">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                        
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <table id="example" class="table table-hover table-striped table-bordered table-responsive" >
                        <thead style="background-color:white; ">
                            <tr>
                                
                                <th>Name</th>
                                <th>Description</th>
                                <th>Remarks</th>
                                <th>
                                    <label id="lbltext1">Selected</label>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <% for (var data = 0; data < TableData.Rows.Count; data++)    
                           { %>
                            <tr>
                                <td><%=TableData.Rows[data]["ingredient_Name"]%>  
                                </td>
    
                                <td><%=TableData.Rows[data]["Description"]%>  
                                </td>

                                <td><% if (int.Parse(TableData.Rows[data][3].ToString()) < 500)
                                        {%>
                                    Please expect delays to your product if selected
                                <%} %>                                    
                                </td>

                                <td>
                                    <input type="checkbox" class="chcktbl1" name="chcktbl1" data-id="  
                                    <%=TableData.Rows[data]["ingredient_Name"]%>" />
                                </td>

                            </tr>
                           <% } %>
                        </tbody>
                    </table>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <br />
        <br />

        <div class="container">
            <div class="row justify-content-center">
            
                <div class="col-6">
                    <div class="row justify-content-center"><asp:Button Class="btn btn-danger" ID="btn_Back" runat="server" Text="Back" OnClick="btn_Back_Click"  /></div>
                </div>

                <div class="col-6">
                    <div class="row justify-content-center"><button type="reset" class="btn btn-primary" ID="btn_Submit">Next</button></div>
                </div>
    
            </div>
        </div>
    </div>
</asp:Content>

