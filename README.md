# GraphQL
.Net Core 3.1 and GraphQL
<div class="mainHeading">
		<h2><u> GraphQL API with .Net Core 3.1</u></h2>
	</div>
	<div class="subHeading">
		Prerequisites
	</div>
	<div class="normalText">
		You should have Visual Studio 2019 with .Net Core 3.1 installed on your system.
	</div>
	<div class="subHeading">
		Getting Started
	</div>
	<div class="normalText">
		1. Open Visual Studio 2019.<br><br>
		Click Create New Project and Select ASP.Net Core Web Application. Press Next button at right bottom.
		<br><br>
		<img src="../img/graphql/VS2019_ProjectSelection.png" /><br><br>

		2. On Next screen Enter Project Name. For Current example it is GraphQLProject. Press Create button at right
		bottom.<br><br>

		3. On the next screen select items as shown in below image. Press Create button at right bottom.<br><br>
		<img src="../img/graphql/VS2019_ProjectCreate.png" /><br><br>

		4. Once the Project is created install below Nuget packages. TO install these packages open Solution Explorer >>
		Right click on the project >> Select Manage Nuget package.<br>
		From Browse Tab, search for below packages and install them.
		<div class="code">
			1. GraphQL Version 2.4.0<br>
			2. GraphiQL Version 2.0.0<br>
			3. GraphQL.Server.Transports.AspNetCore Version 3.4.0<br>
		</div>
		<br><br>

		5. Open the Startup.cs class and add namespace <br>
		&nbsp;&nbsp;&nbsp;

		<pre class="cscode"><code><span class="key">using</span> GraphiQl;</code></pre>

		<br><br>
		Change Configure method like below:<br><br>

		<pre class="cscode"><code> <span class="key">public</span> <span class="key">void</span> Configure(IApplicationBuilder app, IWebHostEnvironment env)
			{
				<span class="key">if</span> (env.IsDevelopment())
				{
					app.UseDeveloperExceptionPage();
				}
	
				app.UseGraphiQl(<span class="str">"/graphql"</span>);
				app.UseMvc();
				app.UseRouting();         
			}</code></pre>
			Configure is used to set up middlewares, routing rules, etc
		<br><br>

		Now run the application. The page will be shown like below:<br><br>
		<img src="../img/graphql/GraphQL_1Page.JPG" />
	</div>
	<div class="subHeading">
		Building Entities
	</div>
	<div class="normalText">
		Now create the below entities. For this right click on the project and Add New Folder. Add below classes
		<br><br>
		<pre class="cscode"><code>
			<span class="key">public</span><span class="key">class</span> Employee			
			 {
				<span class="key">public</span> <span class="key">int</span> Id { <span class="key">get</span>; <span class="key">set</span>; }
		
				<span class="key">public</span> <span class="key">string</span> FirstName { <span class="key">get</span>; <span class="key">set</span>; }
		
				<span class="key">public</span> <span class="key">string</span> LastName { <span class="key">get</span>; <span class="key">set</span>; }
		
				<span class="key">public</span> <span class="key">int</span> Salary { <span class="key">get</span>; <span class="key">set</span>; }
			 }</code></pre>
	</div>
	<div class="subHeading">
		Build Repository class. For current example instead of fetching data from database, we will fetch data from hard
		coded collection.<br><br>

		<pre class="cscode"><code><span class="key">public</span> <span class="key">class</span> EmployeeRepository
		{
				<span class="key">private</span> <span class="key">readonly</span> List&lt;Models.Employee&gt; _employee = <span class="key">new</span> List&lt;Models.Employee&gt;();
		
				<span class="key">public</span> EmployeeRepository()
				{
					Models.Employee employee1 = <span class="key">new</span> Models.Employee
					{
						Id = 1,
						FirstName = <span class="str">"First Name 1"</span>,
						LastName = <span class="str">"Last Name 1"</span>,
						Salary = 1000
					};
					Models.Employee employee2 = <span class="key">new</span> Models.Employee
					{
						Id = 2,
						FirstName = <span class="str">"First Name 2"</span>,
						LastName = <span class="str">"Last Name 2"</span>,
						Salary = 2000
					};
					Models.Employee employee3 = <span class="key">new</span> Models.Employee
					{
						Id = 3,
						FirstName = <span class="str">"First Name 3"</span>,
						LastName = <span class="str">"Last Name 3"</span>,
						Salary = 3000
					};	
		
					_employee.Add(employee1);
					_employee.Add(employee2);
					_employee.Add(employee3);
				}
		
				<span class="key">public</span> List&lt;Models.Employee&gt; GetAll()
				{
					<span class="key">return</span> _employee;
				}
		
				<span class="key">public</span> Models.Employee GetById(<span class="key">int</span> id)
				{
					<span class="key">return</span> _employee.Where(x =&gt; x.Id == id).FirstOrDefault();
				}
		
		
		}</code></pre>
	</div>
	<div class="subHeading">
		Build Service class. This class will fetch data from the repository.<br><br>

		<pre class="cscode"><code> <span class="key">public</span> <span class="key">class</span> EmployeeService
		{
				<span class="key">private</span> EmployeeRepository _employeeRepository ;
				<span class="key">public</span> EmployeeService(EmployeeRepository employeeRepository)
				{
					_employeeRepository = employeeRepository;
				}
		
				<span class="key">public</span> List&lt;Models.Employee&gt; GetAll()
				{
					<span class="key">return</span> _employeeRepository.GetAll();
				}
		
				<span class="key">public</span> Models.Employee GetById(<span class="key">int</span> id)
				{
					<span class="key">return</span> _employeeRepository.GetById(id);
				}
		}</code></pre>
	</div>

	<div class="subHeading">
		Build GraphQL Schema.<br><br>
	</div>
	<div class="normalText">
