using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.AppClasses
{
    public class Entities
    {
        #region Method(s)
        public static string EntityClassSnippet( string className, string nameSpace, string properties, string members )
        {
            string code = "using System;";
            code += "\n" + "using System.Collections.Generic;" + "\n";
            code += "using System.Text;" + "\n\n";
            code += "namespace " + nameSpace + ".Entities" + "\n";
            //open curly brace for namespace
            code += "{" + "\n";
            code += "\t" + "[Serializable]" + "\n";
            code += "\t" + "public class " + className + "\n";
            //open curly brace for class
            code += "\t" + "{" + "\n";
            //code += members + "\n\n";
            //constructor
            code += "\t\t" + "internal " + className + "()" + "\n";
            //constructor open curly brace
            code += "\t\t" + "{" + "\n\n";
            //constructor close curly brace
            code += "\t\t" + "}" + "\n\n";
            //properties
            code += properties + "\n\n";
            //close curly brace for class
            code += "\t" + "}" + "\n";
            //close curly brace for namespace
            code += "}";

            return code;

        }

        public static string PropertiesName( string dataType, string columnName, string memberName )
        {
            string returnValue = "\t\t" + @"///<summary>" + "\n";
            returnValue += "\t\t" + string.Format( @"///({0}){1}", dataType, columnName ) + "\n";
            returnValue += "\t\t" + @"///</summary>" + "\n";
            returnValue += "\t\t" + "public " + dataType + " " + columnName + "\n";
            returnValue += "\t\t" + "{" + "\n";
            returnValue += "\t\t\t" + "get;" + "\n";
            returnValue += "\t\t\t" + "set;" + "\n";
            returnValue += "\t\t" + "}" + "\n";

            return returnValue;
        }

        public static string MemberName( string columnName )
        {
            string memberName = "_";
            string remainingName = columnName.Substring( 1 );
            string firstLetter = columnName.Substring( 0, 1 ).ToLower();

            memberName = memberName + firstLetter + remainingName;

            return memberName;
        }

        public static string Members( string dataType, string memberName )
        {
            string returnValue = "\t\t" + "private " + dataType + " " + memberName + @";";
            return returnValue;
        }


        public static string ClassName( string tableName )
        {
            string returnValue = tableName;
            string lastLetter = tableName.Substring( tableName.Length - 1 ).ToLower().ToString();

            if( string.Equals( "s", lastLetter ) )
            {
                returnValue = tableName.Substring( 0, tableName.Length - 1 );
            }

            return returnValue;
        }

        public static string DataType( string type )
        {
            string returnValue = type;

            switch( type.ToLower() )
            {
                //strings
                case "char":
                    returnValue = "string";
                    break;

                case "varchar":
                    returnValue = "string";
                    break;

                case "text":
                    returnValue = "string";
                    break;

                case "nchar":
                    returnValue = "string";
                    break;

                case "ntext":
                    returnValue = "string";
                    break;

                case "nvarchar":
                    returnValue = "string";
                    break;

                //datetime
                case "date":
                    returnValue = "DateTime";
                    break;

                case "datetime2":
                    returnValue = "DateTime";
                    break;

                case "datetimeoffset":
                    returnValue = "DateTime";
                    break;

                case "smalldatetime":
                    returnValue = "DateTime";
                    break;

                case "time":
                    returnValue = "DateTime";
                    break;

                case "datetime":
                    returnValue = "DateTime";
                    break;

                //numbers
                case "bigint":
                    returnValue = "int";
                    break;

                case "bit":
                    returnValue = "int";
                    break;

                case "money":
                    returnValue = "decimal";
                    break;

                case "numeric":
                    returnValue = "int";
                    break;

                case "smallint":
                    returnValue = "int";
                    break;

                case "smallmoney":
                    returnValue = "decimal";
                    break;

                case "tinyint":
                    returnValue = "byte";
                    break;

                //guid

                case "uniqueidentifier":
                    returnValue = "Guid";
                    break;

                case "real":
                    returnValue = "Single";
                    break;
            }


            return returnValue;
        }
        #endregion
    }
}
