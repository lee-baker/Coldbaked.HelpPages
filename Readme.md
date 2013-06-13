Coldbaked WebAPI HelpPage
-----------------
This is a quick project to abstract the Microsoft ASP.NET Web API Help Page (https://nuget.org/packages/Microsoft.AspNet.WebApi.HelpPage/) into a reusable DLL.

### Setup
1. Make sure the Microsoft Helpage package is not installed in the project
2. Add a refernce to the DLL
3. In the project settings set the XML Documentation File to "app_data\helpdoc.xml"
4. Add an Areas folder and copy the Web.config from the views folder into it.
5. Make sure the project is using the latest versions of the microsoft packages

### Internal Only Documentation attribute
    /// <summary>
	/// 
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>     
	[InternalOnlyDocumentation]
	public string Get(int id)
	{
		return "value";
	}
The documentation for the methods decorated with this attribute will only be displayed if the request is local to the computer.

### Overwriting view files	
Any of the view files that are defined can be overwritten by creating a file with the same name in the same directory structure as the views in the DLL.
Options are: 
- Areas\HelpPage\Views\Help\DisplayTemplates\ApiGroup.cshtml
- Areas\HelpPage\Views\Help\DisplayTemplates\HelpPageApiModel.cshtml
- Areas\HelpPage\Views\Help\DisplayTemplates\ImageSample.cshtml
- Areas\HelpPage\Views\Help\DisplayTemplates\InvalidSample.cshtml
- Areas\HelpPage\Views\Help\DisplayTemplates\Parameters.cshtml
- Areas\HelpPage\Views\Help\DisplayTemplates\Samples.cshtml
- Areas\HelpPage\Views\Help\DisplayTemplates\TextSample.cshtml
- Areas\HelpPage\Views\Help\Api.cshtml
- Areas\HelpPage\Views\Help\Index.cshtml
