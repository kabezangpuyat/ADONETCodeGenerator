namespace CodeGenerator
{
    partial class CodeGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        ///// <summary>
        ///// Required method for Designer support - do not modify
        ///// the contents of this method with the code editor.
        ///// </summary>
        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // CodeGenerator
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size( 292, 266 );
        //    this.Name = "CodeGenerator";
        //    this.Text = "Form1";
        //    this.Load += new System.EventHandler( this.CodeGenerator_Load );
        //    this.ResumeLayout( false );

        //}

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( CodeGenerator ) );
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGenerateClass = new System.Windows.Forms.Button();
            this.cboTables = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDatabases = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.cboServers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbUpdate = new System.Windows.Forms.CheckBox();
            this.cbGetByParameter = new System.Windows.Forms.CheckBox();
            this.cbGet = new System.Windows.Forms.CheckBox();
            this.cbDelete = new System.Windows.Forms.CheckBox();
            this.cbCreate = new System.Windows.Forms.CheckBox();
            this.btnLoadKleo = new System.Windows.Forms.Button();
            this.btnLocalDB = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add( this.btnGenerateClass );
            this.groupBox2.Controls.Add( this.cboTables );
            this.groupBox2.Controls.Add( this.label5 );
            this.groupBox2.Controls.Add( this.cboDatabases );
            this.groupBox2.Controls.Add( this.label4 );
            this.groupBox2.Location = new System.Drawing.Point( 16, 276 );
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size( 303, 112 );
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generate";
            // 
            // btnGenerateClass
            // 
            this.btnGenerateClass.Location = new System.Drawing.Point( 89, 83 );
            this.btnGenerateClass.Name = "btnGenerateClass";
            this.btnGenerateClass.Size = new System.Drawing.Size( 75, 23 );
            this.btnGenerateClass.TabIndex = 7;
            this.btnGenerateClass.Text = "Generate";
            this.btnGenerateClass.UseVisualStyleBackColor = true;
            this.btnGenerateClass.Click += new System.EventHandler( this.btnGenerateClass_Click );
            // 
            // cboTables
            // 
            this.cboTables.FormattingEnabled = true;
            this.cboTables.Location = new System.Drawing.Point( 89, 52 );
            this.cboTables.Name = "cboTables";
            this.cboTables.Size = new System.Drawing.Size( 204, 21 );
            this.cboTables.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label5.Location = new System.Drawing.Point( 20, 60 );
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size( 43, 13 );
            this.label5.TabIndex = 5;
            this.label5.Text = "Table:";
            // 
            // cboDatabases
            // 
            this.cboDatabases.FormattingEnabled = true;
            this.cboDatabases.Location = new System.Drawing.Point( 89, 27 );
            this.cboDatabases.Name = "cboDatabases";
            this.cboDatabases.Size = new System.Drawing.Size( 204, 21 );
            this.cboDatabases.TabIndex = 5;
            this.cboDatabases.SelectedIndexChanged += new System.EventHandler( this.cboDatabases_SelectedIndexChanged );
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label4.Location = new System.Drawing.Point( 18, 35 );
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size( 65, 13 );
            this.label4.TabIndex = 3;
            this.label4.Text = "Database:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add( this.btnLocalDB );
            this.groupBox1.Controls.Add( this.btnLoadKleo );
            this.groupBox1.Controls.Add( this.txtNameSpace );
            this.groupBox1.Controls.Add( this.label12 );
            this.groupBox1.Controls.Add( this.txtServerName );
            this.groupBox1.Controls.Add( this.btnConnect );
            this.groupBox1.Controls.Add( this.txtPassword );
            this.groupBox1.Controls.Add( this.txtUsername );
            this.groupBox1.Controls.Add( this.cboServers );
            this.groupBox1.Controls.Add( this.label3 );
            this.groupBox1.Controls.Add( this.label2 );
            this.groupBox1.Controls.Add( this.label1 );
            this.groupBox1.Location = new System.Drawing.Point( 16, 17 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 303, 173 );
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point( 110, 23 );
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size( 187, 20 );
            this.txtNameSpace.TabIndex = 1;
            this.txtNameSpace.Text = "xxxPROJECTNAMExxx.Core";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label12.Location = new System.Drawing.Point( 20, 31 );
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size( 83, 13 );
            this.label12.TabIndex = 8;
            this.label12.Text = "Name Space:";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point( 94, 53 );
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size( 204, 20 );
            this.txtServerName.TabIndex = 2;
            this.txtServerName.Text = "HP-PC\\SQLEXPRESS";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point( 218, 141 );
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size( 75, 23 );
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler( this.btnConnect_Click );
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point( 92, 106 );
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size( 204, 20 );
            this.txtPassword.TabIndex = 4;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point( 93, 81 );
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size( 204, 20 );
            this.txtUsername.TabIndex = 3;
            // 
            // cboServers
            // 
            this.cboServers.FormattingEnabled = true;
            this.cboServers.Location = new System.Drawing.Point( 93, 52 );
            this.cboServers.Name = "cboServers";
            this.cboServers.Size = new System.Drawing.Size( 204, 21 );
            this.cboServers.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label3.Location = new System.Drawing.Point( 18, 109 );
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size( 65, 13 );
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label2.Location = new System.Drawing.Point( 18, 87 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 42, 13 );
            this.label2.TabIndex = 1;
            this.label2.Text = "Login:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
            this.label1.Location = new System.Drawing.Point( 18, 62 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 48, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add( this.cbUpdate );
            this.groupBox3.Controls.Add( this.cbGetByParameter );
            this.groupBox3.Controls.Add( this.cbGet );
            this.groupBox3.Controls.Add( this.cbDelete );
            this.groupBox3.Controls.Add( this.cbCreate );
            this.groupBox3.Location = new System.Drawing.Point( 16, 196 );
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size( 303, 74 );
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SP Needed";
            // 
            // cbUpdate
            // 
            this.cbUpdate.AutoSize = true;
            this.cbUpdate.Location = new System.Drawing.Point( 201, 20 );
            this.cbUpdate.Name = "cbUpdate";
            this.cbUpdate.Size = new System.Drawing.Size( 61, 17 );
            this.cbUpdate.TabIndex = 4;
            this.cbUpdate.Text = "Update";
            this.cbUpdate.UseVisualStyleBackColor = true;
            // 
            // cbGetByParameter
            // 
            this.cbGetByParameter.AutoSize = true;
            this.cbGetByParameter.Location = new System.Drawing.Point( 94, 44 );
            this.cbGetByParameter.Name = "cbGetByParameter";
            this.cbGetByParameter.Size = new System.Drawing.Size( 89, 17 );
            this.cbGetByParameter.TabIndex = 3;
            this.cbGetByParameter.Text = "Get by param";
            this.cbGetByParameter.UseVisualStyleBackColor = true;
            // 
            // cbGet
            // 
            this.cbGet.AutoSize = true;
            this.cbGet.Location = new System.Drawing.Point( 94, 20 );
            this.cbGet.Name = "cbGet";
            this.cbGet.Size = new System.Drawing.Size( 43, 17 );
            this.cbGet.TabIndex = 2;
            this.cbGet.Text = "Get";
            this.cbGet.UseVisualStyleBackColor = true;
            // 
            // cbDelete
            // 
            this.cbDelete.AutoSize = true;
            this.cbDelete.Location = new System.Drawing.Point( 21, 47 );
            this.cbDelete.Name = "cbDelete";
            this.cbDelete.Size = new System.Drawing.Size( 57, 17 );
            this.cbDelete.TabIndex = 1;
            this.cbDelete.Text = "Delete";
            this.cbDelete.UseVisualStyleBackColor = true;
            // 
            // cbCreate
            // 
            this.cbCreate.AutoSize = true;
            this.cbCreate.Location = new System.Drawing.Point( 21, 23 );
            this.cbCreate.Name = "cbCreate";
            this.cbCreate.Size = new System.Drawing.Size( 57, 17 );
            this.cbCreate.TabIndex = 0;
            this.cbCreate.Text = "Create";
            this.cbCreate.UseVisualStyleBackColor = true;
            // 
            // btnLoadKleo
            // 
            this.btnLoadKleo.Location = new System.Drawing.Point( 62, 141 );
            this.btnLoadKleo.Name = "btnLoadKleo";
            this.btnLoadKleo.Size = new System.Drawing.Size( 75, 23 );
            this.btnLoadKleo.TabIndex = 30;
            this.btnLoadKleo.Text = "Load Kleo";
            this.btnLoadKleo.UseVisualStyleBackColor = true;
            this.btnLoadKleo.Click += new System.EventHandler( this.btnLoadKleo_Click );
            // 
            // btnLocalDB
            // 
            this.btnLocalDB.Location = new System.Drawing.Point( 140, 141 );
            this.btnLocalDB.Name = "btnLocalDB";
            this.btnLocalDB.Size = new System.Drawing.Size( 75, 23 );
            this.btnLocalDB.TabIndex = 31;
            this.btnLocalDB.Text = "Load local DB";
            this.btnLocalDB.UseVisualStyleBackColor = true;
            this.btnLocalDB.Click += new System.EventHandler( this.btnLocalDB_Click );
            // 
            // CodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 340, 398 );
            this.Controls.Add( this.groupBox3 );
            this.Controls.Add( this.groupBox2 );
            this.Controls.Add( this.groupBox1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "CodeGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C# Code Generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.frmCodeGenerator_FormClosed );
            this.Load += new System.EventHandler( this.CodeGenerator_Load );
            this.groupBox2.ResumeLayout( false );
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout( false );
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout( false );
            this.groupBox3.PerformLayout();
            this.ResumeLayout( false );

        }
        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenerateClass;
        private System.Windows.Forms.ComboBox cboTables;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDatabases;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ComboBox cboServers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbUpdate;
        private System.Windows.Forms.CheckBox cbGetByParameter;
        private System.Windows.Forms.CheckBox cbGet;
        private System.Windows.Forms.CheckBox cbDelete;
        private System.Windows.Forms.CheckBox cbCreate;
        private System.Windows.Forms.Button btnLoadKleo;
        private System.Windows.Forms.Button btnLocalDB;
    }
}

