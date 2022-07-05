using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace MTCheckbox
{
  class Utility { 
    /// <summary>
    /// Determines whether the specified control is inside UpdatePanel
    /// </summary>
    /// <param name="control">The control.</param>
    /// <returns>
    /// <c>true</c> if the specified control is inside UpdatePanel; otherwise,
    /// <c>false</c>.
    /// </returns>
    public static bool IsControlInsideUpdatePanel(Control control)
    {
      Control parent = control.Parent;
      while (parent != null)
      {
        if (parent.GetType().FullName.Equals("System.Web.UI.UpdatePanel"))
          return true;
        parent = parent.Parent;
      }
      return false;
    }

    /// <summary>
    /// Determines whether the specified control is in partial rendering.
    /// </summary>
    /// <param name="control">The control.</param>
    /// <returns>
    /// <c>true</c> if the specified control is in partial rendering; otherwise,
    /// <c>false</c>.
    /// </returns>
    public static bool IsControlInPartialRendering(Control control)
    {
      Control parent = control.Parent;
      while (parent != null)
      {
        if (parent.GetType().FullName.Equals("System.Web.UI.UpdatePanel"))
        {
          System.Reflection.PropertyInfo propInfo =
              parent.GetType().GetProperty("IsInPartialRendering");
          if (propInfo != null)
            return (bool)propInfo.GetValue(parent, null);
          else
            return false;
        }
        parent = parent.Parent;
      }
      return false;
    }

    /// <summary>
    /// Determines whether the current postback is being executed in
    /// partial-rendering mode.
    /// </summary>
    /// <param name="page">The page object.</param>
    /// <returns>
    /// <c>true</c> if  the current postback is being executed in
    /// partial-rendering mode; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsInAsyncPostBack(Page page)
    {
      object scriptManager = FindScriptManager(page);
      if (scriptManager != null)
      {
        System.Type smClass = GetScriptManagerType(scriptManager);
        System.Reflection.PropertyInfo propInfo = smClass.GetProperty(
            "IsInAsyncPostBack");
        if (propInfo != null)
          return (bool)propInfo.GetValue(scriptManager, null);
        else
          return false;
      }
      return false;

    }

    private static bool ObjectIsInheritedFrom(Object obj, string fullTypeName)
    {
      Type type = obj.GetType();
      while (type != null)
      {
        if (type.FullName.Equals(fullTypeName)) return true;
        type = type.BaseType;
      }
      return false;
    }

    private static object FindScriptManager(Control parent)
    {
      foreach (Control control in parent.Controls)
      {
        if (ObjectIsInheritedFrom(control, "System.Web.UI.ScriptManager"))
          return control;
        object result = FindScriptManager(control);
        if (result != null) return result;
      }
      return null;
    }

    private static System.Reflection.Assembly ajaxAssembly = null;

    private static void LoadAjaxAssembly()
    {
      if (ajaxAssembly == null)
      {
        ajaxAssembly = System.Reflection.Assembly.LoadFrom(
            "System.Web.Extensions.dll");
      }
    }

    private static System.Type GetTypeFromAjaxAssembly(string className)
    {
      LoadAjaxAssembly();
      if (ajaxAssembly != null)
        return ajaxAssembly.GetType(className);
      else
        return null;
    }


    private static Type GetScriptManagerType(Object obj)
    {
      Type type = obj.GetType();
      while (type != null)
      {
        if (type.FullName.Equals("System.Web.UI.ScriptManager")) return type;
        type = type.BaseType;
      }
      return null;
    }

    /// <summary>
    /// Registers a client script block which will be rendered on each
    /// asynchronous postback.
    /// Works only if ScriptManager control is existed on the page. Otherwise
    /// does nothing.
    /// </summary>
    /// <param name="page">The Page object that is registering the client
    /// script block.</param>
    /// <param name="type">The type of the client script block. </param>
    /// <param name="key">The string that uniquely identifies the
    /// script block.</param>
    /// <param name="script">A string that contains the script.</param>
    /// <param name="addScriptTags">
    ///  A Boolean value that indicates whether to enclose the script
    /// block in <script> tags.
    /// </param>
    public static void RegisterClientScriptBlock(Page page, Type type,
        string key, string script, bool addScriptTags)
    {
      object scriptManager = FindScriptManager(page);
      if (scriptManager != null)
      {
        System.Type smClass = GetScriptManagerType(scriptManager);
        if (smClass != null)
        {
          Object[] args = new Object[] { page, type, key, script,
                        addScriptTags };
          smClass.InvokeMember("RegisterClientScriptBlock",
                  System.Reflection.BindingFlags.Static |
                  System.Reflection.BindingFlags.Public |
                  System.Reflection.BindingFlags.InvokeMethod,
                  null, null, args);
        }
      }
    }

    /// <summary>
    /// Registers a script file which to be rendered each time an asynchronous
    /// postback occurs.
    /// Works only if ScriptManager control is existed on the page. Otherwise
    /// does nothing.
    /// </summary>
    /// <param name="page">The Page object that is registering the client
    /// script file.</param>
    /// <param name="type">The type of the client script file.</param>
    /// <param name="key">The string that uniquely identifies the script file.</param>
    /// <param name="url">The URL that points to the script file.</param>
    public static void RegisterClientScriptInclude(Page page, Type type,
        string key, string url)
    {
      object scriptManager = FindScriptManager(page);
      if (scriptManager != null)
      {
        System.Type smClass = GetScriptManagerType(scriptManager);
        if (smClass != null)
        {
          Object[] args = new Object[] { page, type, key, url };
          smClass.InvokeMember("RegisterClientScriptInclude",
                  System.Reflection.BindingFlags.Static |
                  System.Reflection.BindingFlags.Public |
                  System.Reflection.BindingFlags.InvokeMethod,
                  null, null, args);
        }
      }
    }

    /// <summary>
    /// Registers a script file which to be rendered each time an asynchronous
    /// postback occurs.
    /// Works only if ScriptManager control is existed on the page. Otherwise
    /// does nothing.
    /// </summary>
    /// <param name="page">The page.</param>
    /// <param name="type">The type of the client script file.</param>
    /// <param name="resourceName">The name of resource that contains the
    /// script file.</param>
    public static void RegisterClientScriptResource(Page page, Type type,
        string resourceName)
    {
      object scriptManager = FindScriptManager(page);
      if (scriptManager != null)
      {
        System.Type smClass = GetScriptManagerType(scriptManager);
        if (smClass != null)
        {
          Object[] args = new Object[] { page, type, resourceName };
          smClass.InvokeMember("RegisterClientScriptResource",
                  System.Reflection.BindingFlags.Static |
                  System.Reflection.BindingFlags.Public |
                  System.Reflection.BindingFlags.InvokeMethod,
                  null, null, args);
        }
      }
    }
  }
}