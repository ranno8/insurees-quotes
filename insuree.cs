﻿@* 
<div class="form-group">
    @Html.LabelFor(model => model.Quote, htmlAttributes: new { @class = "control-label col-md-2" })
    <div class="col-md-10">
        @Html.EditorFor(model => model.Quote, new { htmlAttributes = new { @class = "form-control" } })
        @Html.ValidationMessageFor(model => model.Quote, "", new { @class = "text-danger" })
    </div>
</div>
*@

