/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For complete reference see:
	// http://docs.ckeditor.com/#!/api/CKEDITOR.config

	// The toolbar groups arrangement, optimized for a single toolbar row.
	config.toolbarGroups = [
		{ name: 'document',	   groups: [ 'mode', 'document', 'doctools' ] },
		{ name: 'clipboard',   groups: [ 'clipboard', 'undo' ] },
		{ name: 'editing',     groups: [ 'find', 'selection', 'spellchecker' ] },
		{ name: 'forms' },
		{ name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ] },
		{ name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align', 'bidi' ] },
		{ name: 'links' },
		{ name: 'insert' },
		{ name: 'styles' },
		{ name: 'colors' },
		{ name: 'tools' },
		{ name: 'others' },
		{ name: 'about' }
	];

	// The default plugins included in the basic setup define some buttons that
	// are not needed in a basic editor. They are removed here.
	config.removeButtons = 'Cut,Copy,Paste,Undo,Redo,Anchor,Underline,Strike,Subscript,Superscript';

	// Dialog windows are also simplified.
    config.removeDialogTabs = 'link:advanced';
    filebrowserBrowseUrl = "/Areas/Admin/Content/ckfinder/ckfinder.html";
    filebrowserImageBrowseUrl = "/Areas/Admin/Content/ckfinder/ckfinder.html?type=Images";
    filebrowserFlashBrowseUrl = "/Areas/Admin/Content/ckfinder/ckfinder.html?type=Flash";
    filebrowserUploadUrl = "/Areas/Admin/Content/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files";
    filebrowserImageUploadUrl = "/Areas/Admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images";
    filebrowserFlashUploadUrl = "/Areas/Admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";

    CKFinder.setupCKEditor(null, "/Areas/Admin/Content/ckfinder" );
};
