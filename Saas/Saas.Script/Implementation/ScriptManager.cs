using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Saas.Model.Core;
using Saas.Script.Common;
using Saas.Script.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Script.Implementation
{
    public class ScriptManager : IScriptManager
    {
        public void ExecuteScript<T>(string serviceScript, ref T input)
        {
            try
            {
                string inputType = input.GetType().FullName;
                string code = ScriptUtil.GetCSharpScript(serviceScript, inputType);
                var scriptOptions = ScriptUtil.SetReferences(typeof(T));
                var scriptState = CSharpScript.RunAsync(code: code,
                                                        options: scriptOptions,
                                                        globals: new ScriptBaseModel<T> { input = input} 
                                                        ).Result;

                if (scriptState.ReturnValue != null)
                {
                    dynamic returnValue = scriptState.ReturnValue;
                    if (returnValue != null) 
                    {
                        if (returnValue.Input != null)
                        {
                            input = (T)returnValue.Input;
                        }
                        
                    }
                    
                }


                //string inputType = input.GetType().FullName;
                //string csSript = GetCSharpScript(serviceScript, inputType);

                //var scriptOptions = SetReferences(typeof(T));

                //Execute(csSript, scriptOptions);
                //dynamic result = Execute(GetInputFromClass(), scriptOptions);
                //if (result != null)
                //{
                //    string validationMsg = Convert.ToString(result.ValidationMessage);
                //    //if (!String.IsNullOrWhiteSpace(validationMsg))
                //    //    throw new ValidationException(validationMsg);
                //    input = (T)result.input;
                //}
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
}
