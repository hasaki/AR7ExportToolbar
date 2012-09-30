# AR7ExportToolbar

AR7ExportToolbar creates a toolbar button which can be hosted in the [ActiveReports 7] viewer control to let users export reports.

The solution is for Visual Studio 2012, however it can be used in previous versions of Visual Studio by adding the classes to a new solution.  Both C# and VB.NET projects are provided.  To get the samples to work you need to set a property on the PageReport1.rdlx file in the project.  Set it's `Copy to Output Directory` property to `Copy Always`.

This project was introduced in my blog post on the [ComponentOne Blog](http://our.componentone.com/2012/08/29/activereports-7-exports-from-the-viewer/).

## Using the code

To use the button in your own code, just add the classes under the ToolStripExport folder to your project, along with making the ReportViewer.bmp an embedded resource in that folder.  Once you've done that, all you need to do is add the button to your toolbar.

	// C#
	var button = new ExportToolStripButton(viewer);
	// remove exports we don't want to display
	// button.AvailableExports.Remove("PDF");
	
	// Add the toolbar button after the print button in the viewer
	viewer.Toolbar.MainBar.Items.Insert(3, button);
	
	' VB.NET
	Dim button = New ExportToolStripButton(Viewer)
	' remove exports we don't want to display
	' button.AvailableExports.Remove("PDF");

	' Add the toolbar button after the print button in the viewer
	Viewer.Toolbar.MainBar.Items.Insert(3, button)

## Customizing 

The toolbar button allows you to remove exports from the available list, however it must be done before the button is dropped down.  There are a couple options for customizing the button:

1. You can get in the source files and modify it yourself
2. If all you want to do is remove an export, you can modify the AvailableExtensions dictionary to remove the exports you don't want from the drop-down.  Just do this after you create the button and all will be good.

## Exports Supported

Here is a list of the exports supported as well as the `Name` you should specify when wanting to remove the export from the `AvailableExports` dictionary.

<table style="border: 1 solid; width: 250px;">
	<thead>
		<tr><td><strong>Name</strong></td><td><strong>Export</strong></td></tr>
	</thead>
	<tbody>
		<tr><td>PDF</td><td>PDF Export</td></tr>
		<tr><td>HTML</td><td>HTML Export</td></tr>
		<tr><td>Excel</td><td>Excel Export</td></tr>
		<tr><td>RTF</td><td>RTF Export</td></tr>
		<tr><td>Text</td><td>Text Export</td></tr>
		<tr><td>TIFF</td><td>TIFF Export</td></tr>
	</tbody>
</table>			

## Structure 

The toolbar button is provided by the `ExportToolStripButton` class.  This class uses several other classes to work, but by default it will make all exports available that it can find.

As noted in Limitations (below), it doesn't currently list the PageReport specific rendering extensions.  This is due to a limitation in the export functionality in the viewer control that will possibly be removed in the future.  However, some pieces of the C# code have capabilities in them (commented out) to provide support for using the PageReport specific rendering extensions should we add that capability.

### ExportToolStripButton

This class is the only one intended for public use.  It provides a single property to allow users to modify the available list of Exports for the viewer control.

`public IDictionary<string,ExportItem> AvailableExports { get; }` 

When first created, the dictionary returned by this property contains all of the exports available to the button.  Prior to the button being used for the first time, you can modify this dictionary to remove the items you don't want to make available to your users.  After the button has been dropped down, you cannot currently modify the list of available exports.

### Internals

#### Design

The design of the button is relatively simple.  It needs access to the `Viewer` control which is passed in via the constructor.  We use this to hook up to an event that tells us when the report is available as well as giving us access to the `Export` method.

The button exposes a Dictionary which contains all of the exports, if you modify this collection before the button is used then the exports removed won't be available on the button.  

The first time the button is used, the code will attempt to find out if the export types are available and remove any that aren't.  If you're running this on your development machine, we install all the exports in the GAC so all of them will always be available.  However, on your user's machines this may not be the case so we need to remove any that aren't present.

> **Note:** It is recommended that you remove any exports from the `AvailableExports` dictionary that you don't want users to have, even if you don't plan on distributing the assemblies for the exports.  Someone else's application may install those exports, suddenly making them available to your application!

#### ExportItem

The `ExportItem` class ties the export button items to the actual implementation of an export.  Right now the Export functionality is handled by an interface (`ISectionReportExporter`) which is implemented by an abstract class (`SectionReportExporter`).  

`ExportItem` provides a `Name` and `LocalizedName` properties.  While this code doesn't do any localization, the intention is that `Name` should always refer to the English (or invariant) name of the export and is what you use when modifying the AvailableExports dictionary. `LocalizedName` is what will be displayed to users.  

Finally, `ExportItem` provides a `SectionReportExport` property which returns the exporter for this type.  

In the future, there may be an additional `PageReportExport` property (see Limitations below).

#### ISectionReportExporter

The `ISectionReportExporter` interface is the first item that will deal with the export.  It is reponsible for telling the button's code whether the export `IsAvailable()` and if so the correct `IDocumentExportEx` for it.  Lastly it provides some helpers such as the `DefaultExtension` and `FileDialogFilter`.  

> **Note:** These are placed here rather than on the `ExportItem` because when available the `PageReport` specific-exports allow for more customization, including multiple file-types per export (the image export f.e. can export to PNG, GIF, JPG, BMP, and TIFF) so it needs a different implementation than would be suitable for the `SectionReport` specific exports.

#### SectionReportExporter

This abstract class implements the `ISectionReportExporter` with some generic implementation, in particular it provides the basis for finding the correct export type at runtime and abstract properties for the Save As dialog.

##### *SectionReportExporter

These classes pass in the type and assembly name into the SectionReportExporter and provide the proper Save As dialog property values.

## Limitations

Currently the export button cannot provide exports that are specific to the Page Reports (FPL or CPL reports).  This may change in a later version, but will require a newer version of [ActiveReports 7] to work.  Some code exists to provide this support but it is currently commented out, and is not exposed through the public API of the ExportToolStripButton.

## License

The source code contained in this project is licensed under the [MIT license](http://opensource.org/licenses/mit-license.php).  Any referenced libraries retain their original licenses.

> ### Copyright (c) 2012, James Johnson; ComponentOne
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## Support

This code is **not** supported by ComponentOne tech support.  When you use this code in your own project you are taking ownership of any issues involved with it and ComponentOne tech support has **no** obligations to it beyond what they would do if you **wrote it yourself**.  I wrote this in my spare time and it hasn't gone through developer code reviews or QA process except for my own testing.

[ActiveReports 7]: http://www.componentone.com/SuperProducts/ActiveReports/