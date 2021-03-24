/* Code Generator
 * 
 * Data Access Layer Generator for MS databases
 * 
 * Author: McNiel N. Viray
 * Date Created: 21 March 2011
 * Revision History:
 * 2011-03-21, MNV: Initial Version
 * 2014-01-15, MNV: Modified so that it will follow the GAIT Solution format.
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

using Procedure = CodeGenerator.AppClasses.Procedures;
using Manager = CodeGenerator.AppClasses.Managers;
using Entity = CodeGenerator.AppClasses.Entities;

namespace CodeGenerator
{
    public partial class CodeGenerator : Form
    {
        #region Global Private variables
        private static Server _srvSql;

        private string SpCreateName
        {
            get
            {
                return string.Format( "{0}Create{1}", SpPrefix, NewTableName );
            }
        }

        private string SpUpdateName
        {
            get
            {
                return string.Format( "{0}Update{1}", SpPrefix, NewTableName );
            }
        }

        private string SpDeleteName
        {
            get
            {
                return string.Format( "{0}Delete{1}", SpPrefix, NewTableName );
            }
        }

        private string SpPaging
        {
            get
            {
                return string.Format( "{0}Paging{1}", SpPrefix, NewTableName );
            }
        }

        private string SpReadByIdName
        {
            get
            {
                return string.Format( "{0}Read{1}", SpPrefix, NewTableName );
            }
        }

        private string SpReadAllName
        {
            get
            {
                return string.Format( "{0}ReadAll{1}", SpPrefix, NewTableName );
            }
        }

        private string ViewName
        {
            get
            {
                return string.Format( "view{0}", NewTableName );
            }
        }

        private string SpReadAllBySearchCriteriaName
        {
            get
            {
                return string.Format( "{0}ReadAll{1}BySearchCriteria", SpPrefix, NewTableName );
            }
        }

        /// <summary>
        /// Prefix of stored procedure.
        /// </summary>
        private string SpPrefix
        {
            get
            {
                return ConfigurationManager.AppSettings["spNameInitial"].ToString();
            }
        }

        /// <summary>
        /// Business manager folder.
        /// </summary>
        private string ManagerFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["ManagerFolder"].ToString();
            }
        }

        /// <summary>
        /// Namespace of the class
        /// </summary>
        private string NameSpace
        {
            get
            {
                string ns;
                if( IsEmpty( txtNameSpace ) )
                {
                    ns = "Test.CoreManagement";
                }
                else
                {
                    ns = txtNameSpace.Text.Trim();
                }

                return ns;
            }
        }

        /// <summary>
        /// Table name in database.
        /// </summary>
        private string TableName
        {
            get
            {
                return cboTables.Text.Trim();
            }
        }

        private string NewTableName
        {
            get
            {
                string retValue = cboTables.Text.Trim();
                string newValue = retValue.Trim().Substring( retValue.Trim().Length - 1 ).ToLower();

                if( newValue == "s" )
                {
                    retValue = retValue.Trim().Substring( 0, retValue.Trim().Length - 1 );
                }

                return retValue;
            }
        }
        /// <summary>
        /// Database name.
        /// </summary>
        private string DatabaseName
        {
            get
            {
                return cboDatabases.Text.Trim();
            }
        }

        /// <summary>
        /// Business entities folder location.
        /// </summary>
        private string EntitiesFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["BusinessEntityFolder"].ToString();
            }
        }

        /// <summary>
        /// Procedures folder location.
        /// </summary>
        private string ProcedureFolders
        {
            get
            {
                return ConfigurationManager.AppSettings["ProceduresFolder"].ToString();
            }
        }
        #endregion

        #region METHODS
        private void SetProperties()
        {
            Procedure.TableName = TableName;
            Procedure.SpCreateName = SpCreateName;
            Procedure.SpUpdateName = SpUpdateName;
            Procedure.SpDeleteName = SpDeleteName;
            Procedure.SpReadByIDName = SpReadByIdName;
            Procedure.ViewName = ViewName;
            Procedure.SpReadAllBySearchCriteriaName = SpReadAllBySearchCriteriaName;
            Procedure.SpReadAllName = SpReadAllName;

            Manager.NameSpace = NameSpace;
            Manager.TableName = NewTableName;
            Manager.SpCreateName = SpCreateName;
            Manager.SpUpdateName = SpUpdateName;
            Manager.SpDeleteName = SpDeleteName;
            Manager.SpReadByIDName = SpReadByIdName;
            Manager.SpReadAllBySearchCriteriaName = SpReadAllBySearchCriteriaName;
            Manager.SpReadAllName = SpReadAllName;
        }

        #region Create Stream
        /// <summary>
        /// Use to create sql file of the procedures.
        /// </summary>
        private void CreateProcedures( string createProcedure, string readByIdProcedure,
                                        string readAllProcedure, string updateProcedure,
                                            string deleteProcedure, string spPAGING )
        {
            string fileNamePathCreate = string.Format( @"{0}{1}.sql", ProcedureFolders, SpCreateName );
            string fileNamePathRead = string.Format( @"{0}{1}.sql", ProcedureFolders, SpReadByIdName );
            string fileNamePathReadAll = string.Format( @"{0}{1}.sql", ProcedureFolders, SpReadAllName );
            string fileNamePathUpdate = string.Format( @"{0}{1}.sql", ProcedureFolders, SpUpdateName );
            string fileNamePathDelete = string.Format( @"{0}{1}.sql", ProcedureFolders, SpDeleteName );
            string fileNamePathPAGING = string.Format( @"{0}{1}.sql", ProcedureFolders, SpPaging );
            //string fileNamePathView = string.Format( @"{0}{1}.sql", ProcedureFolders, ViewName );
            //string fileNamePathSearchCriteria = string.Format( @"{0}{1}.sql", ProcedureFolders, SpReadAllBySearchCriteriaName );

            //create folder for procedures
            if( !Directory.Exists( ProcedureFolders ) )
            {
                Directory.CreateDirectory( ProcedureFolders );
            }
            if( spPAGING.Trim().Length > 0 )
            {
                WriteStream( fileNamePathPAGING, spPAGING );
            }
            //write create
            if( createProcedure.Trim().Length > 0 )
            {
                WriteStream( fileNamePathCreate, createProcedure );
            }

            if( readByIdProcedure.Trim().Length > 0 )
            {
                //write read
                WriteStream( fileNamePathRead, readByIdProcedure );
            }

            if( readAllProcedure.Trim().Length > 0 )
            {
                //write read all
                WriteStream( fileNamePathReadAll, readAllProcedure );
            }

            if( updateProcedure.Trim().Length > 0 )
            {
                //write update
                WriteStream( fileNamePathUpdate, updateProcedure );
            }
            if( deleteProcedure.Trim().Length > 0 )
            {
                //write delete
                WriteStream( fileNamePathDelete, deleteProcedure );
            }
            //write view
            //WriteStream( fileNamePathView, view_create );

            ////write spreadallsearchcriteria
            //WriteStream( fileNamePathSearchCriteria, spReadAllSearchCriteria );
        }

        /// <summary>
        /// Use to Create business entity object into a file.
        /// </summary>
        private void WriteEntityClass( string className, string businessEntity )
        {
            string fileNamePath = string.Format( @"{0}{1}.cs", EntitiesFolder, className );
            //create folder for business entities
            if( !Directory.Exists( EntitiesFolder ) )
            {
                Directory.CreateDirectory( EntitiesFolder );
            }

            //// *** Write to file ***
            WriteStream( fileNamePath, businessEntity );
        }

        /// <summary>
        /// Use to Create business manager object into a file.
        /// </summary>
        private void WriteManagerClass( string className, string businessEntity )
        {
            string fileNamePath = string.Format( @"{0}{1}.cs", ManagerFolder, className );
            //create folder for business entities
            if( !Directory.Exists( ManagerFolder ) )
            {
                Directory.CreateDirectory( ManagerFolder );
            }

            //// *** Write to file ***
            WriteStream( fileNamePath, businessEntity );
        }

        /// <summary>
        /// Use to write a file stream.
        /// </summary>
        private void WriteStream( string filePath, string content )
        {
            // *** Write to file ***

            // Specify file, instructions, and privelegdes
            FileStream file = new FileStream( filePath, FileMode.OpenOrCreate, FileAccess.Write );

            // Create a new stream to write to the file
            StreamWriter sw = new StreamWriter( file );

            // Write a string to the file
            sw.Write( content );

            // Close StreamWriter
            sw.Close();

            // Close file
            file.Close();
        }
        #endregion

        #region Data Binders
        /// <summary>
        /// Use to get server connection.
        /// </summary>
        private ServerConnection ServerConn( string serverName )
        {
            ServerConnection srvConn = new ServerConnection( serverName );
            if ( txtUsername.Text.Trim().Length > 0 &&
                txtPassword.Text.Trim().Length > 0 )
            {
                // Create a new connection to the selected server name
                //ServerConnection srvConn = new ServerConnection( serverName );
                // Log in using SQL authentication instead of Windows authentication

                srvConn.LoginSecure = false;
                //// Give the login username
                srvConn.Login = txtUsername.Text.Trim();
                //// Give the login password
                srvConn.Password = txtPassword.Text.Trim();
                //// Create a new SQL Server object using the connection we created


            }
            return srvConn;
        }

        /// <summary>
        /// Use to connect into selected sql database server.
        /// </summary>
        private void ConnectToSelectedServer()
        {
            //set up validation
            string msg = string.Empty;
            msg += ValidateData( false );

            //check if validation returns error messages.
            if( !string.Equals( msg, string.Empty ) )
            {
                MessageBox.Show( msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            }
            else
            {
                //_srvSql = new Server( ServerConn( cboServers.SelectedItem.ToString() ) );
                _srvSql = new Server( ServerConn( txtServerName.Text.Trim() ) );

                // Loop through the databases list
                try
                {
                    cboDatabases.Items.Clear();
                    foreach( Database dbServer in _srvSql.Databases )
                    {
                        // Add database to combobox
                        cboDatabases.Items.Add( dbServer.Name );
                    }
                    MessageBox.Show( "You are now connected.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
                catch( ConnectionFailureException cfEx )
                {
                    MessageBox.Show( cfEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    cboDatabases.Items.Clear();
                }
            }
        }

        /// <summary>
        /// Use to bind table name of the selected database into
        /// cboTables.
        /// </summary>
        private void BindddlTables( string dataBaseName )
        {
            if( dataBaseName != null && dataBaseName != "" )
            {
                cboTables.Items.Clear();
                //set up database
                Database db = _srvSql.Databases[dataBaseName];

                //set up tables for the selected database
                TableCollection tables = db.Tables;

                //bind table name into cboTables
                cboTables.Items.Clear();
                foreach( Table table in tables )
                {
                    cboTables.Items.Add( table.Name );
                }
            }
            else
            {
                // A server was not selected, show an error message
                MessageBox.Show( "Please select a database first", "Server Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            }
        }

        /// <summary>
        /// Use to get the columns of the selected table.
        /// </summary>
        private void GetTableColumns()
        {
            if( !string.Equals( TableName, null ) && !string.Equals( DatabaseName, "" ) )
            {
                int count = 0;

                //set up database server
                Database db = _srvSql.Databases[DatabaseName];

                //set up table
                Table table = db.Tables[TableName];

                //variables in creating entity class
                string properties = null;
                string members = null;
                string entityClassSnippets = null;
                string classParamCreate = null;

                //variables in creating stored procedure
                string spDelete = null;
                string spRead = null;
                string spReadAll = null;
                string spUpdate = null;
                string spCreate = null;
                string spPAGING = null;
                //string spReadAllBySearchCriteria = null;
                //string view_Read = null;
                string primaryKeyName = null;
                string primaryKeyValue = null;
                string spUpdateParameters = null;
                string spUpdateColumnsAndParameters = null;
                string spCreateDetailedParameters = null;
                string spCreateColumns = null;
                string spCreateParameters = null;
                string spSelectColumns = null;
                string spSelectCondition = null;
                string spSelectParameter = null;

                //manager class variables
                string managerColumns = string.Empty;
                string createParameters = string.Empty;
                string dbTypesCreate = string.Empty;
                string updateParameters = string.Empty;
                string updateDbTypes = string.Empty;
                string classParamUpdate = string.Empty;
                string pkey = string.Empty;
                string managerSnippets = string.Empty;
                string createInputParams = string.Empty;
                string updateInputParams = string.Empty;
                string spPagingColumn = null;

                int tableCount = table.Columns.Count;

                //get table columns
                foreach( Column column in table.Columns )
                {
                    string columnName = column.Name;
                    count += 1;


                    #region Create Members and Properties
                    //CREATE MEMBER 
                    string memberName = Entity.MemberName( columnName );
                    members += Entity.Members( Entity.DataType( column.DataType.ToString() ), memberName ) + "\n";

                    //CREATE PROPERTIES
                    properties += Entity.PropertiesName( Entity.DataType( column.DataType.ToString() ),
                                                 columnName,
                                                 memberName );
                    #endregion


                    //GENERATE SP
                    //determine if the field is pk
                    string colType = column.DataType.ToString();
                    string typeSize = column.DataType.MaximumLength.ToString();
                    bool isPK = column.InPrimaryKey;
                    string delimeter = string.Empty;


                    //set up delimeter ',' value
                    if( count < tableCount )
                    {
                        delimeter = ",";
                    }


                    #region Create sp_Delete
                    //generate readAll sp
                    if( bool.Equals( isPK, true ) )
                    {
                        spDelete = cbDelete.Checked == true ?
                                Procedure.Delete( "@" + columnName,
                                              columnName,
                                              colType.ToUpper() + Procedure.ParamDataType( colType, typeSize ) )
                                : string.Empty;
                        //this will be used in ReadById sp generator
                        primaryKeyName = columnName;
                        primaryKeyValue = "@" + columnName;
                        //select proc
                        //spSelectParameter = string.Format( "\t" + "@{0} {1} ({2})", columnName,
                        //                                                   colType.ToUpper(),
                        //                                                   typeSize );
                        spSelectParameter = string.Format( "\t" + "@{0} {1}", columnName,
                                                                           colType.ToUpper() );

                        spSelectCondition = string.Format( " {0} = @{1}", columnName, columnName );

                        //readAll manager class
                        pkey = columnName;

                    }
                    #endregion

                    #region Create sp_Update and Create sp_Created
                    if( int.Equals( count, 1 ) )
                    {
                        //parameters for readAll
                        spUpdateParameters += "\t" + "@" + columnName + " " + colType.ToUpper() +
                                     Procedure.ParamDataType( colType, typeSize ) + delimeter + "\n";


                        if( !isPK )
                        {
                            spUpdateColumnsAndParameters += string.Format( "\t\t" + "[{0}] = ISNULL(@{1},{2}){3}" + "\n", columnName,
                                                                                                        columnName,
                                                                                                        columnName,
                                                                                                        delimeter );

                            spCreateDetailedParameters += string.Format( "\t" + "@{0} {1} {2}{3}" + "\n", columnName,
                                                                                                    colType.ToUpper(),
                                                                                                    Procedure.ParamDataType( colType, typeSize ),
                                                                                                    delimeter );
                            spCreateColumns += string.Format( "\t\t" + "[{0}]{1}" + "\n", columnName, delimeter );
                            spCreateParameters += string.Format( "\t\t" + "@{0}{1}" + "\n", columnName, delimeter );

                            //create input parameter
                            createParameters += "\"" + columnName + "\"" + delimeter;
                            dbTypesCreate += Manager.DBTypeValue( colType ) + delimeter;
                            classParamCreate += Entity.DataType( colType ) + " " + columnName.ToLower() + delimeter;
                            createInputParams += columnName + delimeter;
                        }
                        //value for Select By Id Procedure
                        spSelectColumns += string.Format( "\t\t" + "[{0}]{1}" + "\n", columnName, delimeter );
                        
                        spPagingColumn += 
                            string.Format( "\t\t" + "[{0}] = {1}.{2}{3}" + "\n", 
                                columnName, 
                                columnName.Substring( 0, 1 ).ToLower(),
                                columnName,
                                delimeter );


                        //readAll input parameter
                        updateParameters += "\"" + columnName + "\"" + delimeter;
                        updateDbTypes += Manager.DBTypeValue( colType ) + delimeter;
                        classParamUpdate += Entity.DataType( colType ) + " " + columnName.ToLower() + delimeter;
                        updateInputParams += columnName + delimeter;
                    }
                    else
                    {
                        spUpdateParameters += "\t" + "@" + columnName + " " + colType.ToUpper() +
                            Procedure.ParamDataType( colType, typeSize ) + " = NULL " + delimeter + "\n";

                        if( !isPK )
                        {
                            spUpdateColumnsAndParameters += string.Format( "\t\t" + "[{0}] = ISNULL(@{1},{2}){3}" + "\n", columnName,
                                                                                                        columnName,
                                                                                                        columnName,
                                                                                                        delimeter );
                            //value for Insert Procedure
                            spCreateDetailedParameters += string.Format( "\t" + "@{0} {1} {2}{3}" + "\n", columnName,
                                                                                                  colType.ToUpper(),
                                                                                                  Procedure.ParamDataType( colType, typeSize ),
                                                                                                  delimeter );
                            spCreateColumns += string.Format( "\t\t" + "[{0}]{1}" + "\n", columnName, delimeter );
                            spCreateParameters += string.Format( "\t\t" + "@{0}{1}" + "\n", columnName, delimeter );
                            //create input parameter
                            createParameters += "\"" + columnName + "\"" + delimeter;
                            dbTypesCreate += Manager.DBTypeValue( colType ) + delimeter;
                            classParamCreate += Entity.DataType( colType ) + " " + columnName.ToLower() + delimeter;
                            createInputParams += columnName + delimeter;
                        }
                        //value for Select By Id Procedure
                        spSelectColumns += string.Format( "\t\t" + "[{0}]{1}" + "\n", columnName, delimeter );
                        spPagingColumn +=
                           string.Format( "\t\t" + "{0} = {1}.{2}{3}" + "\n",
                               columnName,
                               columnName.Substring( 0, 1 ).ToLower(),
                               columnName,
                               delimeter );

                        //readAll input parameter
                        updateParameters += "\"" + columnName + "\"" + delimeter;
                        updateDbTypes += Manager.DBTypeValue( colType ) + delimeter;
                        classParamUpdate += Entity.DataType( colType ) + " " + columnName.ToLower() + delimeter;
                        updateInputParams += columnName + delimeter;
                    }
                    //for business manager
                    managerColumns += "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "\t" + Manager.SetUpManager( colType, columnName ) + "\n";
                    #endregion

                }

                #region Output Entity Class
                entityClassSnippets = Entity.EntityClassSnippet( NewTableName,
                                          NameSpace,
                                          properties,
                                          members );
                WriteEntityClass( NewTableName, entityClassSnippets );
                #endregion

                #region Output Procedures

                //output sp_Update

                spUpdate =
                    cbUpdate.Checked == true ?
                            Procedure.Update( spUpdateParameters,
                                       spUpdateColumnsAndParameters,
                                       primaryKeyName,
                                       primaryKeyValue )
                            : string.Empty;

          
                //output sp_Create

                spCreate =
                    cbCreate.Checked == true ? 
                                    Procedure.Create( spCreateDetailedParameters, 
                                                      spCreateColumns, 
                                                      spCreateParameters 
                                                     )
                                    : string.Empty;
                //output sp_ReadById
                spRead =
                    cbGetByParameter.Checked == true ?
                        Procedure.ReadByID( spSelectParameter, spSelectColumns, spSelectCondition )
                        : string.Empty;

                //Read all
                spReadAll =
                    cbGet.Checked == true ?
                        Procedure.ReadAll( spSelectColumns )
                        : string.Empty;

                spPAGING =
                    Procedure.PAGING( spSelectColumns, spPagingColumn );
                //view_Read = Procedure.ViewCreate( spSelectColumns );

                //spReadAllBySearchCriteria = 
                //    Procedure.ReadAllBySearchCriteria();

                try
                {
                    CreateProcedures( spCreate,
                                     spRead,
                                     spReadAll,
                                     spUpdate,
                                     spDelete,
                                     spPAGING );
                }
                catch( Exception ex )
                {
                    string a = ex.Message;
                }
                #endregion

                #region Output Manager Class
                managerSnippets = Manager.Create( managerColumns,
                                                             createParameters,
                                                             dbTypesCreate,
                                                             classParamCreate,
                                                             updateParameters,
                                                             updateDbTypes,
                                                             classParamUpdate,
                                                             pkey,
                                                             createInputParams,
                                                             updateInputParams,
                                                             cbCreate.Checked,
                                                             cbGetByParameter.Checked,
                                                             cbGet.Checked,
                                                             cbUpdate.Checked,
                                                             cbDelete.Checked );
                WriteManagerClass( NewTableName + "Manager", managerSnippets );
                #endregion
            }
        }
        #endregion

        #region Validations
        /// <summary>
        /// Validates all the required fields needed upon clicking the buttons.
        /// </summary>
        private string ValidateData( bool isGenerate )
        {

            string msg = string.Empty;

            if( IsEmpty( txtServerName ) )
            {
                msg += "Please fill up server name. \n";
            }
            //if( IsEmpty( txtUsername ) )
            //{
            //    msg += "Please fill up username. \n";
            //}
            //if( IsEmpty( txtPassword ) )
            //{
            //    msg += "Please fill up password. \n";
            //}


            //validation if the button generate is clicked.
            if( bool.Equals( isGenerate, true ) )
            {
                //btn generate
                if( cboDatabases.SelectedItem != null && cboDatabases.SelectedItem.ToString() != "" )
                {
                    msg = string.Empty;
                }
                else
                {
                    msg += "Please select database. \n";
                }
                if( cboTables.SelectedItem != null && cboTables.SelectedItem.ToString() != "" )
                {
                    msg = string.Empty;
                }
                else
                {
                    msg += "Please select table. \n";
                }
            }

            return msg;
        }

        /// <summary>
        /// Validate textbox if it is empty or not.
        /// </summary>
        private bool IsEmpty( TextBox textbox )
        {
            bool returnValue = false;

            switch( textbox.Text.Trim() )
            {
                case "":
                    returnValue = true;
                    break;
                case null:
                    returnValue = true;
                    break;
            }

            return returnValue;
        }
        #endregion

        #endregion

        #region Constructor
        public CodeGenerator()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void CodeGenerator_Load( object sender, EventArgs e )
        {
            Form form1 = new Form();
            //form1.Icon = Properties.Resources.cg;        
        }
        private void btnConnect_Click( object sender, EventArgs e )
        {
            ConnectToSelectedServer();
        }
        private void btnGenerateClass_Click( object sender, EventArgs e )
        {
            string msg = string.Empty;
            SetProperties();
            msg += ValidateData( true );

            if( !string.Equals( msg, string.Empty ) )
            {
                MessageBox.Show( msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            }
            else
            {
                msg = string.Empty;
                try
                {
                    //generate here.
                    //need to get all the columns of the table and determine its datatype
                    //GetTableColumns1( cboTables.Text, cboDatabases.Text );
                    GetTableColumns();
                    msg = "Code Generated in the following path:" + "\n\n" +
                          EntitiesFolder + "\n" +
                          ProcedureFolders + "\n" +
                          ManagerFolder;
                }
                catch( Exception ex )
                {
                    msg = ex.Message;
                }

                MessageBox.Show( msg, "Code Generator", MessageBoxButtons.OK, MessageBoxIcon.Information );

            }
        }
        private void cboDatabases_SelectedIndexChanged( object sender, EventArgs e )
        {
            BindddlTables( cboDatabases.Text );
        }

        private void frmCodeGenerator_FormClosed( object sender, FormClosedEventArgs e )
        {
            DialogResult result = MessageBox.Show( "Do you want to exit application?",
                                                   "Code Generator",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question );
            if( result == DialogResult.Yes )
            {
                Application.Exit();
            }
            else
            {
                Application.Restart();
            }
        }
        private void btnLocalDB_Click( object sender, EventArgs e )
        {
            txtServerName.Text = @"HP-PC\SQLEXPRESS";
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtNameSpace.Text = "xxxPROJECTNAMExxx.Core";
        }

        private void btnLoadKleo_Click( object sender, EventArgs e )
        {
            txtServerName.Text = @"test.adoptaclassroomtest.com";
            txtUsername.Text = "webtest";
            txtPassword.Text = "VctEYDwW";
            txtNameSpace.Text = "Kleo.DAL";
        }
        #endregion
    }
}
