using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CodeGenerator.AppClasses
{
    public class Managers
    {
        #region Properties
        private static string _tableName;
        public static string TableName
        {
            get
            {
                return Managers._tableName;
            }
            set
            {
                Managers._tableName = value;
            }
        }

        private static string _nameSpace;
        public static string NameSpace
        {
            get
            {
                return Managers._nameSpace;
            }
            set
            {
                Managers._nameSpace = value;
            }
        }

        private static string _spReadAllName;
        public static string SpReadAllName
        {
            get
            {
                return Managers._spReadAllName;
            }
            set
            {
                Managers._spReadAllName = value;
            }
        }

        private static string _spReadByIDName;
        public static string SpReadByIDName
        {
            get
            {
                return Managers._spReadByIDName;
            }
            set
            {
                Managers._spReadByIDName = value;
            }
        }
        
        private static string _spDeleteName;
        public static string SpDeleteName
        {
            get
            {
                return Managers._spDeleteName;
            }
            set
            {
                Managers._spDeleteName = value;
            }
        }

        private static string _spUpdateName;
        public static string SpUpdateName
        {
            get
            {
                return Managers._spUpdateName;
            }
            set
            {
                Managers._spUpdateName = value;
            }
        }

        private static string _spCreateName;
        public static string SpCreateName
        {
            get
            {
                return Managers._spCreateName;
            }
            set
            {
                Managers._spCreateName = value;
            }
        }

        private static string _spReadAllBySearchCriteriaName;
        public static string SpReadAllBySearchCriteriaName
        {
            get
            {
                return Managers._spReadAllBySearchCriteriaName;
            }
            set
            {
                Managers._spReadAllBySearchCriteriaName = value;
            }
        }
        #endregion

        #region Methods
        public static string Create( string columnName, string parameters, string dbTypesCreate, string classParamCreate,
                    string updateParameters, string updateDbTypes, string classparamUpdate, string pkey,
                    string createInputParams, string updateInputParams )
        {
            string managerClass = "";
            managerClass += "using System;" + "\n";
            managerClass += "using System.Collections.Generic;" + "\n";
            managerClass += "using System.Text;" + "\n";
            managerClass += "using System.Data.SqlClient;" + "\n";
            managerClass += "using System.Data;" + "\n";
            managerClass += "using System.Linq;" + "\n" + "\n";
            managerClass += "using " + ConfigurationManager.AppSettings["SqlClient.dll"].ToString() + ";" + "\n";
            managerClass += "using " + NameSpace + ".Entities;" + "\n" + "\n";
            managerClass += "namespace " + NameSpace + ".Manager" + "\n";
            managerClass += "{" + "\n";
            managerClass += "\t" + "public static class " + TableName + "Manager" + "\n";
            managerClass += "\t" + "{" + "\n";
            managerClass += ManagerCreate( parameters, dbTypesCreate, classParamCreate, createInputParams ) + "\n" + "\n";
            managerClass += ManagerUpdate( updateParameters, updateDbTypes, classparamUpdate, updateInputParams ) + "\n" + "\n";
            managerClass += ManagerDelete( pkey ) + "\n" + "\n";
            managerClass += ManagerRead( pkey ) + "\n" + "\n";
            managerClass += ManagerReadAll() + "\n" + "\n";            
            managerClass += "\t" + "\t" + "#region Private Methods" + "\n";
            #region Single Entity
            //Single entity
            managerClass += "\t" + "\t" + "/// <summary>" + "\n";
            managerClass += "\t" + "\t" + "/// Execute command reader." + "\n";
            managerClass += "\t" + "\t" + "/// </summary>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"procName\">Either stored procedure name or tsql.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"parameters\">Stored procedure parameter(s) without @ sign.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"inputParams\">Stored procedure parameter value(s).</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"isSp\">[Optional] True when stored procedure.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <returns>Single value entity of " + TableName + ".</returns>" + "\n";
            managerClass += "\t" + "\t" + "private static " + TableName + " CommandReader( string procName, string[] parameters = null,object[] inputParams = null, bool isSp = true )" + "\n";
            managerClass += "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + string.Format( "{0} entity = new {0}();", TableName ) + "\n";
            managerClass += "\t" + "\t" + "\t" + "using ( SqlDataReader dataReader = parameters != null ?" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "DBHelper.ExecuteDataReader( procName, parameters, inputParams, DataSource.DBConnection, isSp ) :" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "DBHelper.ExecuteDataReader( procName, DataSource.DBConnection, isSp ) )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "if ( dataReader.HasRows )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "if ( dataReader.Read() )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + columnName + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "return entity;" + "\n";
            managerClass += "\t" + "\t" + "}" + "\n";
            #endregion
            #region List Entity
            managerClass += "\t" + "\t" + "/// <summary>" + "\n";
            managerClass += "\t" + "\t" + "/// Execute command reader." + "\n";
            managerClass += "\t" + "\t" + "/// </summary>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"procName\">Either stored procedure name or tsql.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"parameters\">Stored procedure parameter(s) without @ sign.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"inputParams\">Stored procedure parameter value(s).</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"isSp\">[Optional] True when stored procedure.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <returns>List entity of " + TableName + ".</returns>" + "\n";
            managerClass += "\t" + "\t" + "private static List<" + TableName + "> CommandReaders( string procName, string[] parameters = null,object[] inputParams = null, bool isSp = true )" + "\n";
            managerClass += "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + string.Format( "List<{0}> entities = new List<{0}>();", TableName ) + "\n";
            managerClass += "\t" + "\t" + "\t" + "using ( SqlDataReader dataReader = parameters != null ?" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "DBHelper.ExecuteDataReader( procName, parameters, inputParams, DataSource.DBConnection,isSp ) :" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "DBHelper.ExecuteDataReader( procName, DataSource.DBConnection, isSp ) )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "if ( dataReader.HasRows )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "while ( dataReader.Read() )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "entities.Add" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "(" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + string.Format( "new {0}()", TableName ) + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "{" + "\n";
            string newColnameFormat = columnName.Replace( "entity.", "" ).Replace( ";", "," );
            newColnameFormat = newColnameFormat.Substring( 0, newColnameFormat.Trim().Length );
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + newColnameFormat + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + ");" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "return entities;" + "\n";
            managerClass += "\t" + "\t" + "}" + "\n";
            #endregion
            managerClass += "\t" + "\t" + "#endregion" + "\n";
            managerClass += "\t" + "}" + "\n";
            managerClass += "}" + "\n";
            return managerClass;
        }
        public static string Create( string columnName, string parameters, string dbTypesCreate, string classParamCreate,
            string updateParameters, string updateDbTypes, string classparamUpdate, string pkey,
            string createInputParams, string updateInputParams, bool isCreate, bool isGetByParam, bool isGet,
            bool isUpdate, bool isDelete )
        {
            string managerClass = "";
            managerClass += "using System;" + "\n";
            managerClass += "using System.Collections.Generic;" + "\n";
            managerClass += "using System.Text;" + "\n";
            managerClass += "using System.Data.SqlClient;" + "\n";
            managerClass += "using System.Data;" + "\n";
            managerClass += "using System.Linq;" + "\n" + "\n";
            managerClass += "using " + ConfigurationManager.AppSettings["SqlClient.dll"].ToString() + ";" + "\n";
            managerClass += "using " + NameSpace + ".Entities;" + "\n" + "\n";
            managerClass += "namespace " + NameSpace + ".Managers" + "\n";
            managerClass += "{" + "\n";
            managerClass += "\t" + "public static class " + TableName + "Manager" + "\n";
            managerClass += "\t" + "{" + "\n";
            if( isCreate == true )
            {
                managerClass += ManagerCreate( parameters, dbTypesCreate, classParamCreate, createInputParams ) + "\n";
            }
            if( isUpdate == true )
            {
                managerClass += ManagerUpdate( updateParameters, updateDbTypes, classparamUpdate, updateInputParams ) + "\n";
            }
            if( isDelete == true )
            {
                managerClass += ManagerDelete( pkey ) + "\n";
            }
            if( isGetByParam == true )
            {
                managerClass += ManagerRead( pkey ) + "\n";
            }
            if( isGet == true )
            {
                managerClass += ManagerReadAll() + "\n";
            }            
            managerClass += "\t" + "\t" + "#region Private Methods" + "\n";
            #region Single Entity
            //Single entity
            managerClass += "\t" + "\t" + "/// <summary>" + "\n";
            managerClass += "\t" + "\t" + "/// Execute command reader." + "\n";
            managerClass += "\t" + "\t" + "/// </summary>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"procName\">Either stored procedure name or tsql.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"parameters\">Stored procedure parameter(s) without @ sign.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"inputParams\">Stored procedure parameter value(s).</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"isSp\">[Optional] True when stored procedure.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <returns>Single value entity of " + TableName + ".</returns>" + "\n";
            managerClass += "\t" + "\t" + "private static " + TableName + " CommandReader( string procName, string[] parameters = null,object[] inputParams = null, bool isSp = true )" + "\n";
            managerClass += "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + string.Format( "{0} entity = new {0}();", TableName ) + "\n";
            managerClass += "\t" + "\t" + "\t" + "using ( SqlDataReader dataReader = parameters != null ?" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "DBHelper.ExecuteDataReader( procName, parameters, inputParams, DataSource.DBConnection, isSp ) :" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "DBHelper.ExecuteDataReader( procName, DataSource.DBConnection, isSp ) )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "if ( dataReader.HasRows )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "if ( dataReader.Read() )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + columnName + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "return entity;" + "\n";
            managerClass += "\t" + "\t" + "}" + "\n";
            #endregion
            #region List Entity
            managerClass += "\t" + "\t" + "/// <summary>" + "\n";
            managerClass += "\t" + "\t" + "/// Execute command reader." + "\n";
            managerClass += "\t" + "\t" + "/// </summary>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"procName\">Either stored procedure name or tsql.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"parameters\">Stored procedure parameter(s) without @ sign.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"inputParams\">Stored procedure parameter value(s).</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <param name=\"isSp\">[Optional] True when stored procedure.</param>" + "\n";
            managerClass += "\t" + "\t" + "/// <returns>List entity of " + TableName + ".</returns>" + "\n";
            managerClass += "\t" + "\t" + "private static List<" + TableName + "> CommandReaders( string procName, string[] parameters = null,object[] inputParams = null, bool isSp = true )" + "\n";
            managerClass += "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + string.Format( "List<{0}> entities = new List<{0}>();", TableName ) + "\n";
            managerClass += "\t" + "\t" + "\t" + "using ( SqlDataReader dataReader = parameters != null ?" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "DBHelper.ExecuteDataReader( procName, parameters, inputParams, DataSource.DBConnection,isSp ) :" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "DBHelper.ExecuteDataReader( procName, DataSource.DBConnection, isSp ) )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "if ( dataReader.HasRows )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "while ( dataReader.Read() )" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "{" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "entities.Add" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "(" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + string.Format( "new {0}()", TableName ) + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "{" + "\n";
            string newColnameFormat = columnName.Replace( "entity.", "" ).Replace( ";", "," );
            newColnameFormat = newColnameFormat.Substring( 0, newColnameFormat.TrimEnd().Length - 1 );
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + newColnameFormat + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + ");" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "}" + "\n";
            managerClass += "\t" + "\t" + "\t" + "return entities;" + "\n";
            managerClass += "\t" + "\t" + "}" + "\n";
            #endregion
            managerClass += "\t" + "\t" + "#endregion" + "\n";

            managerClass += "\t" + "}" + "\n";
            managerClass += "}" + "\n";
            return managerClass;
        }

        public static string SetUpManager( string colTye, string colName )
        {
            string returnValue = string.Format( "entity.{0} = dataReader[\"{1}\"];", colName, colName );

            switch( colTye.ToLower() )
            {
                //strings
                case "char":
                    returnValue = string.Format( "entity.{0} = dataReader[\"{1}\"].ToString();", colName,
                                                                                              colName );
                    break;

                case "varchar":
                    returnValue = string.Format( "entity.{0} = dataReader[\"{1}\"].ToString();", colName,
                                                                                            colName );
                    break;

                case "text":
                    returnValue = string.Format( "entity.{0} = dataReader[\"{1}\"].ToString();", colName,
                                                                                            colName );
                    break;

                case "nchar":
                    returnValue = string.Format( "entity.{0} = dataReader[\"{1}\"].ToString();", colName,
                                                                                            colName );
                    break;

                case "ntext":
                    returnValue = string.Format( "entity.{0} = dataReader[\"{1}\"].ToString();", colName,
                                                                                            colName );
                    break;

                case "nvarchar":
                    returnValue = string.Format( "entity.{0} = dataReader[\"{1}\"].ToString();", colName,
                                                                                            colName );
                    break;

                //datetime
                case "date":
                    returnValue = string.Format( "entity.{0} = Convert.ToDateTime( dataReader[\"{1}\"] );", colName,
                                                                                            colName );
                    break;

                case "datetime2":
                    returnValue = string.Format( "entity.{0} = Convert.ToDateTime( dataReader[\"{1}\"] );", colName,
                                                                                            colName );
                    break;

                case "datetimeoffset":
                    returnValue = string.Format( "entity.{0} = Convert.ToDateTime( dataReader[\"{1}\"] );", colName,
                                                                                            colName );
                    break;

                case "smalldatetime":
                    returnValue = string.Format( "entity.{0} = Convert.ToDateTime( dataReader[\"{1}\"] );", colName,
                                                                                             colName );
                    break;

                case "time":
                    returnValue = string.Format( "entity.{0} = Convert.ToDateTime( dataReader[\"{1}\"] );", colName,
                                                                                            colName );
                    break;

                case "datetime":
                    returnValue = string.Format( "entity.{0} = Convert.ToDateTime( dataReader[\"{1}\"] );", colName,
                                                                                             colName );
                    break;

                //numbers
                case "bigint":
                    returnValue = string.Format( "entity.{0} = Convert.ToInt32( dataReader[\"{1}\"] );", colName,
                                                                                            colName );
                    break;

                case "bit":
                    returnValue = string.Format( "entity.{0} = Convert.ToInt16( dataReader[\"{1}\"] );", colName,
                                                                                           colName );
                    break;

                case "money":
                    returnValue = string.Format( "entity.{0} = Convert.ToDecimal( dataReader[\"{1}\"] );", colName,
                                                                                           colName );
                    break;

                case "float":

                    returnValue = string.Format( "entity.{0} = Convert.ToInt64( dataReader[\"{1}\"] );", colName,
                                                                                         colName );

                    break;

                case "numeric":
                    returnValue = string.Format( "entity.{0} = Convert.ToInt32( dataReader[\"{1}\"] );", colName,
                                                                                         colName );
                    break;

                case "smallint":
                    returnValue = string.Format( "entity.{0} = Convert.ToInt16( dataReader[\"{1}\"] );", colName,
                                                                                         colName );
                    break;

                case "smallmoney":
                    returnValue = string.Format( "entity.{0} = Convert.ToDecimal( dataReader[\"{1}\"] );", colName,
                                                                                         colName );
                    break;

                case "tinyint":
                    returnValue = string.Format( "entity.{0} = Convert.ToByte( dataReader[\"{1}\"] );", colName,
                                                                                         colName );
                    break;

                case "int":
                    returnValue = string.Format( "entity.{0} = Convert.ToInt32( dataReader[\"{1}\"] );", colName,
                                                                                         colName );
                    break;

                case "decimal":
                    returnValue = string.Format( "entity.{0} = Convert.ToDecimal( dataReader[\"{1}\"] );", colName,
                                                                                         colName );
                    break;

                case "uniqueidentifier":
                    returnValue = string.Format( "entity.{0} = new Guid( dataReader[\"{1}\"].ToString() );", colName,
                                                                    colName );

                    break;
                case "real":
                    returnValue = string.Format( "entity.{0} = Convert.ToSingle( dataReader[\"{1}\"] );", colName,
                                                                                         colName );

                    break;
            }

            return returnValue;
        }

        public static string DBTypeValue( string type )
        {
            string returnValue = type;
            switch( type.ToLower() )
            {
                //strings
                case "char":
                    returnValue = "DbType.String";
                    break;

                case "varchar":
                    returnValue = "DbType.String";
                    break;

                case "text":
                    returnValue = "DbType.String";
                    break;

                case "nchar":
                    returnValue = "DbType.String";
                    break;

                case "ntext":
                    returnValue = "DbType.String";
                    break;

                case "nvarchar":
                    returnValue = "DbType.String";
                    break;

                //datetime
                case "date":
                    returnValue = "DbType.DateTime";
                    break;

                case "datetime2":
                    returnValue = "DbType.DateTime";
                    break;

                case "datetimeoffset":
                    returnValue = "DbType.DateTime";
                    break;

                case "smalldatetime":
                    returnValue = "DbType.DateTime";
                    break;

                case "time":
                    returnValue = "DbType.DateTime";
                    break;

                case "datetime":
                    returnValue = "DbType.DateTime";
                    break;

                //numbers
                case "float":
                    returnValue = "DbType.Int64";
                    break;

                case "bigint":
                    returnValue = "DbType.Int32";
                    break;

                case "bit":
                    returnValue = "DbType.Int16";
                    break;

                case "money":
                    returnValue = "DbType.Decimal";
                    break;

                case "numeric":
                    returnValue = "DbType.Int32";
                    break;

                case "smallint":
                    returnValue = "DbType.Int16";
                    break;

                case "smallmoney":
                    returnValue = "DbType.Decimal";
                    break;

                case "decimal":
                    returnValue = "DbType.Decimal";
                    break;

                case "tinyint":
                    returnValue = "DbType.Byte";
                    break;

                case "int":
                    returnValue = "DbType.Int32";
                    break;

                //guid

                case "uniqueidentifier":
                    returnValue = "DbType.Guid";
                    break;

                case "real":
                    returnValue = "DbType.Single";
                    break;
            }

            return returnValue;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Use to to manage Create method of manager class.
        /// </summary>
        private static string ManagerCreate( string parameters, string dbTypes, string classParamCreate,
            string createInputParams )
        {
            string create = "";

            create += "\t" + "\t" + "#region Create" + "\n";
            create += "\t" + "\t" + "public static int Create( " + classParamCreate + " )" + "\n";
            create += "\t" + "\t" + "{" + "\n";
            create += "\t" + "\t" + "\t" + "//set up variables" + "\n";
            create += "\t" + "\t" + "\t" + "string procName = \"" + SpCreateName + "\";" + "\n";
            create += "\t" + "\t" + "\t" + "string[] parameters = { " + parameters + " };" + "\n";
            create += "\t" + "\t" + "\t" + "object[] inputParams = { " + createInputParams.ToLower() + " };" + "\n" + "\n";
            create += "\t" + "\t" + "\t" + "int retValue = 0;" + "\n" + "\n";
            create += "\t" + "\t" + "\t" + "//execute" + "\n";
            //try catch block
            create += "\t" + "\t" + "\t" + "try" + "\n";
            create += "\t" + "\t" + "\t" + "{" + "\n";
            create += "\t" + "\t" + "\t" + "\t" + "DBHelper.ExecuteNonQuery( procName, parameters, inputParams, DataSource.DBConnection, out retValue );" + "\n";
            create += "\t" + "\t" + "\t" + "}" + "\n";
            create += "\t" + "\t" + "\t" + "catch( Exception ex )" + "\n";
            create += "\t" + "\t" + "\t" + "{" + "\n";
            create += "\t" + "\t" + "\t" + "\t" + " throw new ArgumentException( ex.Message, ex.InnerException );" + "\n";
            create += "\t" + "\t" + "\t" + "}" + "\n" + "\n";
            create += "\t" + "\t" + "\t" + "return retValue;" + "\n";
            create += "\t" + "\t" + "}" + "\n";           
            create += "\t" + "\t" + "#endregion" + "\n";
            return create;
        }
        /// <summary>
        /// Use to to manage Update method of manager class.
        /// </summary>
        private static string ManagerUpdate( string updateParameters, string updateDbTypes,
            string classParamUpdate, string updateInputParams )
        {
            string update = "";
            update += "\t" + "\t" + "#region Update" + "\n";
            update += "\t" + "\t" + "public static void Edit( " + classParamUpdate + " )" + "\n";
            update += "\t" + "\t" + "{" + "\n";
            update += "\t" + "\t" + "\t" + "//set up variables" + "\n";
            update += "\t" + "\t" + "\t" + "string procName = \"" + SpUpdateName + "\";" + "\n";
            update += "\t" + "\t" + "\t" + "string[] parameters = { " + updateParameters + " };" + "\n";
            update += "\t" + "\t" + "\t" + "object[] inputParams = { " + updateInputParams.ToLower() + " };" + "\n" + "\n";
            update += "\t" + "\t" + "\t" + "//execute" + "\n";
            update += "\t" + "\t" + "\t" + "DBHelper.ExecuteNonQuery( procName, parameters, inputParams, DataSource.DBConnection );" + "\n" + "\n";

            update += "\t" + "\t" + "}" + "\n";
            update += "\t" + "\t" + "#endregion" + "\n";
            return update;
        }

        /// <summary>
        /// Use to to manage Delete method of manager class.
        /// </summary>
        private static string ManagerDelete( string pkey )
        {
            string delete = "";

            delete += "\t" + "\t" + "#region Delete" + "\n";
            delete += "\t" + "\t" + "public static void Delete( int " + pkey.ToLower() + " )" + "\n";
            delete += "\t" + "\t" + "{" + "\n";
            delete += "\t" + "\t" + "\t" + "//set up variables" + "\n";
            delete += "\t" + "\t" + "\t" + "string procName = \"" + SpDeleteName + "\";" + "\n";
            delete += "\t" + "\t" + "\t" + "string[] parameters = { \"" + pkey + "\" };" + "\n";
            delete += "\t" + "\t" + "\t" + "object[] inputParams = { " + pkey.ToLower() + " };" + "\n" + "\n";
            delete += "\t" + "\t" + "\t" + "//execute" + "\n";
            delete += "\t" + "\t" + "\t" + "DBHelper.ExecuteNonQuery( procName, parameters, inputParams, DataSource.DBConnection );" + "\n" + "\n";
            delete += "\t" + "\t" + "}" + "\n";
            delete += "\t" + "\t" + "#endregion" + "\n";

            return delete;
        }

        /// <summary>
        /// Use to to manage ReadById method of manager class.
        /// </summary>
        private static string ManagerRead( string pkey )
        {
            string readById = "";

            readById += "\t" + "\t" + "#region Read" + "\n";
            //readById += "\t" + "\t" + "public static " + TableName + " GetById( int " + pkey.ToLower() + " )" + "\n";
            readById += "\t" + "\t" + "public static " + TableName + string.Format( " Get( {0} {1} )", ConfigurationManager.AppSettings["ReadByIDDatatype"].ToString(), pkey.ToLower() ) + "\n";
            readById += "\t" + "\t" + "{" + "\n";
            readById += "\t" + "\t" + "\t" + "//set up variables" + "\n";
            readById += "\t" + "\t" + "\t" + "string procName = \"" + SpReadByIDName + "\";" + "\n";
            readById += "\t" + "\t" + "\t" + "string[] parameters = { \"" + pkey + "\" };" + "\n";
            readById += "\t" + "\t" + "\t" + "object[] inputParams = { " + pkey.ToLower() + " };" + "\n" + "\n";
            readById += "\t" + "\t" + "\t" + "//execute" + "\n";
            readById += "\t" + "\t" + "\t" + "return CommandReader( procName, parameters, inputParams );" + "\n";
            readById += "\t" + "\t" + "}" + "\n";
            readById += "\t" + "\t" + "#endregion" + "\n";
            return readById;
        }

        /// <summary>
        /// Use to to manage ReadAll method of manager class.
        /// </summary>
        private static string ManagerReadAll()
        {
            string readAll = "";

            readAll += "\t" + "\t" + "#region Read All" + "\n";
            readAll += "\t" + "\t" + "public static List<" + TableName + "> GetAll()" + "\n";
            readAll += "\t" + "\t" + "{" + "\n";
            readAll += "\t" + "\t" + "\t" + "//set up variables" + "\n";
            readAll += "\t" + "\t" + "\t" + "string procName = \"" + SpReadAllName + "\";" + "\n";
            readAll += "\t" + "\t" + "\t" + "//execute" + "\n";
            readAll += "\t" + "\t" + "\t" + "return CommandReaders( procName );" + "\n";
            readAll += "\t" + "\t" + "}" + "\n";
            readAll += "\t" + "\t" + "#endregion" + "\n";
            return readAll;
        }      
        #endregion
    }
}
