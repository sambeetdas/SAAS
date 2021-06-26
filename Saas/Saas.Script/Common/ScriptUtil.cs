using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Saas.Script.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Script.Common
{
    public class ScriptUtil
    {
        public static string GetCSharpScript(string serviceScript, string inputType)
        {
            string inputSript = GetBaseStript();
            inputSript = inputSript.Replace("$$TYPE$$", inputType);
            inputSript = inputSript.Replace("$$INTERNALSCRIPT$$", serviceScript);

            return inputSript;
        }

        private static string GetBaseStript()
        {
            //string csScript = @" public class BaseClass
            //{
            //    public BaseModel baseModel { get; set; }
            //    public BaseClass()
            //    {
            //       baseModel = new BaseModel();
            //       var input = baseModel.input;
            //       $$INTERNALSCRIPT$$
            //    }

            //    private void ValidationMessage(string msg)
            //    {
            //       baseModel.ValidationMessage += msg;
            //    }
            //}
            //public class BaseModel
            //{
            //    public BaseModel()
            //    {
            //        input = new $$TYPE$$();
            //    }
            //    public $$TYPE$$ input { get; set; }
            //    public string ValidationMessage { get; set; }
            //}";

            string csScript = @"ScriptOutputModel Execute($$TYPE$$ input)
                                {
                                  $$INTERNALSCRIPT$$
                                  
                                  ScriptOutputModel srpOModel = new ScriptOutputModel();
                                  srpOModel.Input = input;

                                  return srpOModel;
                                }
                                 

                                return Execute(input);

                                public class ScriptOutputModel
                                {
                                 public $$TYPE$$ Input { get; set; }
                                 public string Error { get; set; }
                                }
                                ";

            return csScript;
        }

        //private string GetInputFromClass()
        //{
        //    string csSript = @" new BaseClass().baseModel ";

        //    return csSript;
        //}

        public static ScriptOptions SetReferences(Type type)
        {
            var scriptOptions = ScriptOptions.Default;

            // Add reference to mscorlib
            var baselib = type.Assembly;
            var validationexplib = typeof(System.ComponentModel.DataAnnotations.ValidationException).GetTypeInfo().Assembly;

            var references = new[] { baselib, validationexplib };
            scriptOptions = scriptOptions.AddReferences(references);

            // Add namespaces
            scriptOptions = scriptOptions.AddImports("System.ComponentModel.DataAnnotations");

            return scriptOptions;
        }

        //private static ScriptState<object> scriptState = null;
        //private static object Execute(string code, dynamic scriptOptions)
        //{
        //    try
        //    {
        //        scriptState = scriptState == null ? CSharpScript.RunAsync(code, scriptOptions).Result : scriptState.ContinueWithAsync(code).Result;
        //        if (scriptState.ReturnValue != null && !string.IsNullOrEmpty(scriptState.ReturnValue.ToString()))
        //            return scriptState.ReturnValue;
        //        return null;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
