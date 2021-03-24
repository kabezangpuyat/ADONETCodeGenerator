using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace CodeGenerator.AppClasses
{
    public class Procedures
    {
        #region Properties
        private static string _spReadAllName;

        public static string SpReadAllName
        {
            get
            {
                return Procedures._spReadAllName;
            }
            set
            {
                Procedures._spReadAllName = value;
            }
        }
        private static string _viewName;

        public static string ViewName
        {
            get
            {
                return Procedures._viewName;
            }
            set
            {
                Procedures._viewName = value;
            }
        }
        private static string _spReadByIDName;

        public static string SpReadByIDName
        {
            get
            {
                return Procedures._spReadByIDName;
            }
            set
            {
                Procedures._spReadByIDName = value;
            }
        }
        private static string _spDeleteName;

        public static string SpDeleteName
        {
            get
            {
                return Procedures._spDeleteName;
            }
            set
            {
                Procedures._spDeleteName = value;
            }
        }
        private static string _spUpdateName;

        public static string SpUpdateName
        {
            get
            {
                return Procedures._spUpdateName;
            }
            set
            {
                Procedures._spUpdateName = value;
            }
        }

        private static string _spCreateName;
        public static string SpCreateName
        {
            get
            {
                return Procedures._spCreateName;
            }
            set
            {
                Procedures._spCreateName = value;
            }
        }

        private static string _tableName;

        public static string TableName
        {
            get
            {
                return Procedures._tableName;
            }
            set
            {
                Procedures._tableName = value;
            }
        }

        private static string _spReadAllBySearchCriteriaName;

        public static string SpReadAllBySearchCriteriaName
        {
            get
            {
                return Procedures._spReadAllBySearchCriteriaName;
            }
            set
            {
                Procedures._spReadAllBySearchCriteriaName = value;
            }
        }
        #endregion

        #region Methods
        private static string BannerValue( string spName )
        {
            string bannerValue = string.Empty;
            //try
            //{
            //    StreamReader sr =
            //        //new StreamReader( File.OpenRead( ConfigurationManager.AppSettings["bannerPath"].ToString() ) );
            //        new StreamReader(File.OpenRead( "C:\\banner.txt"));

            //    string banner = sr.ReadToEnd();
            //    sr.Close();
            //    banner = banner.Replace( "xxxPROCEDURENAMExxx", spName );
            //    banner = banner.Replace( "xxxDATENOWxxx", DateTime.Now.ToShortDateString() );

            //    bannerValue = banner;
            
            //}
            //catch
            //{
            //}
            return bannerValue;
        }
        public static string Create( string spDetailedParameters, string columns, string spParams )
        {
            string retValue = null;

            retValue += "CREATE PROCEDURE [dbo].[" + SpCreateName + "]" + "\n";
            retValue += spDetailedParameters;
            retValue += BannerValue( SpCreateName ) + "\n";
            retValue += "AS" + "\n";
            retValue += "BEGIN" + "\n";
            retValue += "\t" + "INSERT INTO [" + TableName + "]" + "\n";
            retValue += "\t" + "(" + "\n";
            #region OtherColumns
            string delimeter = ",";
            string[] otherCols = columns.Split( ',' );
            string otherCol = string.Empty;
            for( int i = 0; i < otherCols.Length; i++ )
            {
                if( i == 0 )
                {
                    otherCol += otherCols[i].ToString() + delimeter;
                }
                else
                {
                    otherCol += "\t\t\t\t" + otherCols[i].ToString() + ( i < ( otherCols.Length - 1 ) ? delimeter : "" );
                }
            }
            retValue += otherCol;
            #endregion
            retValue += "\t" + ")" + "\n";
            retValue += "\t" + "VALUES" + "\n";
            retValue += "\t" + "(" + "\n";
            retValue += spParams;
            retValue += "\t" + ")" + "\n";
            retValue += "\t" + "SELECT SCOPE_IDENTITY()" + "\n";
            retValue += "END" + "\n";
            //retValue += "RETURN 0;";

            return retValue;
        }

        public static string Update( string spParams, string columnsAndParams, string pkName, string pkValue )
        {
            string retValue = null;
            retValue = string.Format( "CREATE PROCEDURE [dbo].[{0}]" + "\n" +
                                     "{1}" + "\n" +
                                     "{2}" + "\n" + 
                                     "AS" + "\n" +
                                     "BEGIN" + "\n" +
                                     "\t" + "UPDATE [{3}]" + "\n" +
                                     "\t" + "SET" + "\n" +
                                     "{4}" +
                                     "\t" + "WHERE {5} = {6}" + "\n" +
                                     "END" + "\n" +
                                     "RETURN 0;", SpUpdateName,
                                                          spParams,
                                                          BannerValue( SpUpdateName ),
                                                          TableName,
                                                          columnsAndParams,
                                                          pkName,
                                                          pkValue );


            return retValue;
        }

        public static string Delete( string spParam, string column, string dataType )
        {
            string retValue = null;

            retValue += "CREATE PROCEDURE [dbo].[" + SpDeleteName + "]" + "\n";
            retValue += "\t" + spParam + " " + dataType + "\n";
            retValue += BannerValue( SpDeleteName ) + "\n";
            retValue += "AS" + "\n";
            retValue += "BEGIN" + "\n";
            retValue += "\t" + "DELETE FROM [" + TableName + "] WHERE " + column + " = " + spParam + "\n";
            retValue += "END" + "\n";
            retValue += "RETURN 0;";

            return retValue;
        }

        public static string ReadByID( string spParam, string columns, string condition )
        {
            string retValue = null;
            retValue += "CREATE PROCEDURE [dbo].[" + SpReadByIDName + "]" + "\n";
            retValue += spParam + "\n";
            retValue += BannerValue( SpReadByIDName ) + "\n";
            retValue += "AS" + "\n";
            retValue += "BEGIN" + "\n";
            retValue += "\t" + "SELECT " + "\n";
            #region OtherColumns
            string delimeter = ",";
            string[] otherCols = columns.Split( ',' );
            string otherCol = string.Empty;
            for( int i = 0; i < otherCols.Length; i++ )
            {
                if( i == 0 )
                {
                    otherCol += otherCols[i].ToString() + delimeter;
                }
                else
                {
                    otherCol += "\t\t\t\t" + otherCols[i].ToString() + ( i < ( otherCols.Length - 1 ) ? delimeter : "" );
                }
            }
            retValue += otherCol;
            #endregion
            retValue += "\t" + "FROM [" + TableName + "] (NOLOCK)" + "\n";
            retValue += "\t" + "WHERE " + condition + "\n";
            retValue += "END" + "\n";
            retValue += "RETURN 0;";

            return retValue;
        }

        public static string PAGING( string columns, string newColumn )
        {
            string retValue = null;

            retValue += "CREATE PROCEDURE [dbo].[" + SpReadByIDName + @"Paging]" + "\n";
	        retValue += "\t\t" + "@PageIndex INT," + "\n";
	        retValue += "\t\t" + "@PageSize INT" + "\n";
            retValue += "AS" + "\n";
            retValue += "BEGIN" + "\n";
	        retValue += "\t\t" + "DECLARE @StartRowIndex INT;" + "\n";
	        retValue += "\t\t" + "SET @StartRowIndex = (@PageIndex * @PageSize) + 1;" + "\n";	
	        retValue += "\t\t" + "WITH TmpTable AS" + "\n";
	        retValue += "\t\t" + "(" + "\n";
		    retValue += "\t\t\t" + "SELECT ROW_NUMBER() OVER (ORDER BY ID ASC) AS ROW," + "\n";
            string delimeter = ",";

            #region NewColumns
            string[] tempCols = newColumn.Split( ',' );
            string tempCol = string.Empty;
            for( int i = 0; i < tempCols.Length; i++ )
            {
                if( i == 0 )
                {
                    tempCol += tempCols[i].ToString() + delimeter;
                }
                else
                {
                    tempCol += "\t\t\t" + tempCols[i].ToString() + ( i < ( tempCols.Length - 1 ) ? delimeter : "" );
                }
            }
            retValue += tempCol;
            #endregion
            
		    retValue += "\t\t\t" + "FROM [" + TableName + @"] t ( NOLOCK )" + "\n";
	        retValue += "\t\t" + ")" + "\n\n";                	
	        retValue += "\t\t" + "SELECT" + "\n";

            #region OtherColumns
            string[] otherCols = columns.Split( ',' );
            string otherCol = string.Empty;
            for( int i = 0; i < otherCols.Length; i++ )
            {
                if( i == 0 )
                {
                    otherCol += otherCols[i].ToString() + delimeter;
                }
                else
                {
                    otherCol += "\t\t\t\t" + otherCols[i].ToString() + ( i < ( otherCols.Length - 1 ) ? delimeter : "" );
                }
            }
            #endregion

            retValue += otherCol;
	        retValue += "\t\t" + "FROM TmpTable" + "\n";
	        retValue += "\t\t" + "WHERE ROW BETWEEN @StartRowIndex AND @StartRowIndex+@PageSize-1;" + "\n";
            retValue += "END" + "\n";
            retValue += "RETURN 0" + "\n";
            retValue += "GO";

            return retValue;
        }

        public static string ViewCreate( string columns )
        {
            string retValue = null;
            retValue += "CREATE VIEW [dbo].[" + ViewName + "]" + "\n";
            retValue += "\n";
            retValue += "AS" + "\n";
            retValue += "\t" + "SELECT " + "\n";

            #region OtherColumns
            string delimeter = ",";
            string[] otherCols = columns.Split( ',' );
            string otherCol = string.Empty;
            for( int i = 0; i < otherCols.Length; i++ )
            {
                if( i == 0 )
                {
                    otherCol += otherCols[i].ToString() + delimeter;
                }
                else
                {
                    otherCol += "\t\t\t\t" + otherCols[i].ToString() + ( i < ( otherCols.Length - 1 ) ? delimeter : "" );
                }
            }
            retValue += otherCol;
            #endregion
            retValue += "\t" + "FROM [" + TableName + "] (NOLOCK)" + "\n";

            return retValue;
        }

        public static string ReadAllBySearchCriteria()
        {
            string retValue = null;
            retValue += "CREATE PROCEDURE [dbo].[" + SpReadAllBySearchCriteriaName + "]" + "\n";
            retValue += "\t" + "@WhereClause NVARCHAR(4000)" + "\n";
            retValue += "AS" + "\n";
            retValue += "BEGIN" + "\n" + "\n";
            retValue += "\t" + "DECLARE @SQL NVARCHAR (4000)" + "\n" + "\n";
            retValue += "\t" + "SET @SQL = N'SELECT * FROM [" + ViewName + "] '" + "\n" + "\n";
            retValue += "\t" + "IF @WhereClause IS NOT NULL AND @WhereClause <> ''" + "\n";
            retValue += "\t" + "\t" + "SET @SQL = @SQL + N' WHERE ' + @WhereClause" + "\n";
            retValue += "\t" + "EXEC SP_EXECUTESQL @SQL" + "\n";
            retValue += "END" + "\n";
            retValue += "RETURN 0;";

            return retValue;
        }

        public static string ReadAll( string columns )
        {
            string retValue = null;
            retValue += "CREATE PROCEDURE [dbo].[" + SpReadAllName + "]" + "\n";
            retValue += "\n";
            retValue += BannerValue( SpReadAllName ) + "\n";
            retValue += "AS" + "\n";
            retValue += "BEGIN" + "\n";
            retValue += "\t" + "SELECT " + "\n";
            retValue += columns;
            retValue += "\t" + "FROM [" + TableName + "] (NOLOCK)" + "\n";
            retValue += "END" + "\n";
            retValue += "RETURN 0;";

            return retValue;
        }

        public static string ParamDataType( string type, string origSize )
        {
            string returnValue = string.Empty;
            string size = origSize == "-1" ? "MAX" : origSize;
            switch( type.ToLower() )
            {
                //strings
                case "char":
                    returnValue = string.Format( "({0})", size );
                    break;

                case "varchar":
                    returnValue = string.Format( "({0})", size );
                    break;

                case "text":
                    returnValue = string.Empty;
                    break;

                case "nchar":
                    returnValue = string.Format( "({0})", size );
                    break;

                case "ntext":
                    returnValue = string.Empty;
                    break;

                case "nvarchar":
                    returnValue = string.Format( "({0})", size );
                    break;

                //datetime
                case "date":
                    returnValue = string.Empty;
                    break;

                case "datetime2":
                    returnValue = string.Empty;
                    break;

                case "datetimeoffset":
                    returnValue = string.Empty;
                    break;

                case "smalldatetime":
                    returnValue = string.Empty;
                    break;

                case "time":
                    returnValue = string.Empty;
                    break;

                case "datetime":
                    returnValue = string.Empty;
                    break;

                //numbers
                case "bigint":
                    returnValue = string.Empty;
                    break;

                case "bit":
                    returnValue = string.Empty;
                    break;

                case "money":
                    returnValue = string.Empty;
                    break;

                case "numeric":
                    returnValue = string.Empty;
                    break;

                case "smallint":
                    returnValue = string.Empty;
                    break;

                case "smallmoney":
                    returnValue = string.Empty;
                    break;

                case "tinyint":
                    returnValue = string.Empty;
                    break;
                case "real":
                    returnValue = string.Empty;
                    break;
                //guid

                case "uniqueidentifier":
                    returnValue = string.Empty;
                    break;

                default:
                    returnValue = string.Empty;
                    break;
            }


            return returnValue;
        }
        #endregion

    }
}
