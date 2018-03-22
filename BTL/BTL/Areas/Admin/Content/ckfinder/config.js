/*
Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
For licensing, see license.txt or http://cksource.com/ckfinder/license
*/

CKFinder.customConfig = function( config )
{
	// Define changes to default configuration here.
	// For the list of available options, check:
	// http://docs.cksource.com/ckfinder_2.x_api/symbols/CKFinder.config.html

	// Sample configuration options:
	// config.uiColor = '#BDE31E';
	// config.language = 'fr';
    // config.removePlugins = 'basket';
        filebrowserBrowseUrl ="/Areas/Admin/Content/ckfinder/ckfinder.html",
        filebrowserImageBrowseUrl = "/Areas/Admin/Content/ckfinder/ckfinder.html?type=Images",
        filebrowserFlashBrowseUrl = "/Areas/Admin/Content/ckfinder/ckfinder.html?type=Flash",
        filebrowserUploadUrl = "/Areas/Admin/Content/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files",
        filebrowserImageUploadUrl = "/Areas/Admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images",
        filebrowserFlashUploadUrl = "/Areas/Admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash"
};
