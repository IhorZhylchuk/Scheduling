#pragma checksum "C:\Users\Igor\source\repos\Scheduling\Scheduling\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "907ff9d1db9edc54cd2e371eadb5830ac59e6f96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Igor\source\repos\Scheduling\Scheduling\Views\_ViewImports.cshtml"
using Scheduling;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Igor\source\repos\Scheduling\Scheduling\Views\_ViewImports.cshtml"
using Scheduling.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"907ff9d1db9edc54cd2e371eadb5830ac59e6f96", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adb72943db91b94fc42e6f5b350f3b07a498016e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/datepicker.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Igor\source\repos\Scheduling\Scheduling\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var error = ViewBag.Error;


#line default
#line hidden
#nullable disable
            WriteLiteral("<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\" />\r\n<header>\r\n    <a class=\"btn btn-primary\"");
            BeginWriteAttribute("onclick", " onclick=\"", 237, "\"", 300, 3);
            WriteAttributeValue("", 247, "MakeReservation(\'", 247, 17, true);
#nullable restore
#line 9 "C:\Users\Igor\source\repos\Scheduling\Scheduling\Views\Home\Index.cshtml"
WriteAttributeValue("", 264, Url.Action("Reservation", "Home"), 264, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 298, "\')", 298, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Make reservation</a>\r\n    <a class=\"btn btn-primary\" onclick=\"Click()\">Some button</a>\r\n</header>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "907ff9d1db9edc54cd2e371eadb5830ac59e6f964594", async() => {
                WriteLiteral(@"
    <table id=""reservations"" class=""table table-striped table-bordered display"" style=""width:100%; margin-top: 10px"">
        <thead>
            <tr>
                <th></th>
                <th class=""styleTh"" date>Date</th>
                <th class=""styleTh"">Time</th>
                <th class=""styleTh"">Specialist</th>
                <th></th>
            </tr>
        </thead>
    </table>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"" />
<link href=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.css"" rel=""stylesheet"" />
<link href=""https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.3/css/bootstrap.min.css"" rel=""stylesheet"" />
<link href=""https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/css/bootstrap-datepicker.min.css"" rel=""stylesheet"" />
<link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.10.22/css/jquery.dataTables.css"">

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script src=\"https://unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>\r\n    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.29.1/moment.min.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "907ff9d1db9edc54cd2e371eadb5830ac59e6f966878", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/notify/0.4.2/notify.min.js""></script>
    <script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.10.22/js/jquery.dataTables.js""></script>
    <script>
        var Popup, dataTable;

        

        $(document).ready(function () {
            dataTable = $('#reservations').DataTable({
                dom: 'Bfrtip',
                ajax: {
                    url: '/Home/GetData',
                    type: 'GET',
                    dataSrc: ''
                },
                rowId: 'Id',
                order: [[1, 'asc']],
                columns: [
                    { data: null, 'sortable': false, 'className': 'dt-center' },
                    { data: 'date', 'className': 'dt-center', 'render': function (data) { return moment(data).format('D.M.YYYY') } },
                    { data: 'time', 'className': 'dt-center' },
                    { data: 'specialist', 'className': 'dt-center' },
         ");
                WriteLiteral(@"           {
                        data: 'id', 'className': 'dt-center', 'render': function (data) {
                            return ""<div style='width:100%; position: center'><div class='btn-group' role='group' id='groupButton'><a class='btn btn-danger btn-small' onclick=Delete("" + data + "") id='Delete' style = 'height: 5 %, initial; margin-left: 2px '><i class='fa fa-trash' aria-hidden='true'></i> Delete</a ></div></div >""
                        },
                        orderable: false,
                        searchable: false,
                        width: '150px'
                    }
                ],
                language: {
                    emptyTable: 'You have no reservations yet!'
                }
            });
            
            $('#reservations').DataTable().on('order.dt search.dt', function () {
                $('#reservations').DataTable().column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                    cell.inne");
                WriteLiteral(@"rHTML = i + 1;
                });
            }).draw();
        });

        function Click() {
            alert('Click');
        }

        function MakeReservation(url) {
            var formDiv = $('<div/>');
            $.get(url)
                .done(function (response) {
                    formDiv.html(response);
                    Popup = formDiv.dialog({
                        autoOpen: true,
                        modal: true,
                        draggable: true,
                        position: { my: ""center"", at: ""top"", of: window },
                        resizable: false,
                        title: 'Make reservation',
                        height: 550,
                        width: 700,
                        close: function () {
                            $(this).closest('.ui-dialog-content').dialog('destroy').remove();
                        }
                    });
                });
        }
        function SubmitForm(form) {
        ");
                WriteLiteral(@"    $.validator.unobtrusive.parse(form);
            if ($(form).valid()) {
                $.ajax({
                    type: ""POST"",
                    url: form.action,
                    data: $(form).serialize(),
                    success: function (data) {
                        if (data.success) {
                            Popup.dialog('close');
                            $(""reservations"").DataTable().ajax.reload();
                        }
                        /*
                        else {
                            $(function () {
                                $.getScript(""/Home/Reservation"");
                            });
                            
                            $(function () {
                                $.ajax({
                                    url: '/Home/Reservation',
                                    type: ""POST"",
                                    success: function (data) { alert(data.message) },
                             ");
                WriteLiteral(@"   });});
                                
                        }
                        */
                    }
                });
            }
        }
        function Delete(id) {
                Swal.fire({
                title: 'Delete this reservation?',
                text: ""You won't be able to revert this!"",
                icon: 'question',
                showCancelButton: true,
                showConfirmButton: true,
                cancelButtonText: 'Cancel',
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
                        }).then((result) => {
            if (result.isConfirmed) {
                    $.ajax({
                    type: 'POST',
                    url: '");
#nullable restore
#line 149 "C:\Users\Igor\source\repos\Scheduling\Scheduling\Views\Home\Index.cshtml"
                     Write(Url.Action("Delete", "Home"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/' + id,
                    success: function(data) {
                        if (data.success) {
                            $('#reservations').DataTable().ajax.reload(null, false);
                            //setTimeout(function () { location.reload()}, 2000);
                        }
                    }
                })
                    Swal.fire(
                        'Deleted!',
                        'The item has been deleted.',
                        'success'
                    )
                }
                })
        }

    </script>

");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591