CREATE TABLE [dbo].[paymentRecord]
(
	[idPaymentRecord] INT NOT NULL PRIMARY KEY, 
    [idUser] INT NULL, 
    [anount] INT NULL, 
    [recurrence] INT NULL, 
    [recurrenceType] INT NULL, 
    [paymentDate] DATE NULL, 
    [serviceType] INT NULL, 
    [detail] VARCHAR(500) NULL, 
    [provider] INT NULL
);



Create procedure [dbo].[AddNewPayment](
	@idPaymentRecord int,
	@idUser int,
    @anount float,
    @recurrence int,
    @recurrenceType int,
    @paymentDate date,
    @serviceType int,
	@detail varchar(500),
    @provider varchar(500)
)  
as
begin
	Insert into paymentRecord values(
		@idPaymentRecord,
		@idUser,
		@anount,
		@recurrence,
		@recurrenceType,
		@paymentDate,
		@serviceType,
		@detail,
		@provider
	)
End


ALTER TABLE dbo.paymentRecord ALTER COLUMN serviceType int NULL;



Create procedure [dbo].[UpdatePayment](  
	@idPaymentRecord int,
	@idUser int,
	@amount float,
	@recurrence int,
	@recurrenceType int,
	@paymentDate date,
	@serviceType int,
	@detail varchar(500),
	@provider varchar(500)
) 
as  
begin  
	UPDATE [paymentRecord]   
		SET
		[idUser] = @idUser,
		[amount] = @amount,
		[recurrence] = @recurrence,
		[recurrenceType] = @recurrenceType,
		[paymentDate] = @paymentDate,
		[serviceType] = @serviceType,
		[detail] = @detail,
		provider = @provider
			WHERE [idPaymentRecord] = @idPaymentRecord
End


Create procedure [dbo].[DeletePayment](  
   @idPaymentRecord int  
)  
as   
begin  
   DELETE FROM paymentRecord where idPaymentRecord=@idPaymentRecord 
End




/*=======================Provider=========================*/

Create or alter  procedure [dbo].[AddNewProvider](
	@detail varchar(500)
)  
as
begin
	Insert into provider values(
		@detail
	)
End


Create or alter  procedure [dbo].[UpdateProvider](  
	@id int,
	@detail varchar(500)
) 
as  
begin  
	UPDATE [provider]   
		SET
		[detail] = @detail
			WHERE [id] = @id
End


Create procedure [dbo].[DeleteProvider](  
   @id int  
)  
as   
begin  
   DELETE FROM provider where id=@id 
End


Create Procedure [dbo].[GetProviders]  
as  
begin  
   select * from provider
End


/*==================recurenceType=========================*/


Create or alter procedure [dbo].[AddNewRecurenceType](
	@detail varchar(500),
	@days int
)  
as
begin
	Insert into recurenceType values(
		@detail,
		@days
	)
End



Create or alter procedure [dbo].[UpdateRecurenceType](  
	@id int,
	@detail varchar(500),
	@days int
) 
as  
begin  
	UPDATE [recurenceType]   
		SET
		[detail] = @detail,
		[days] = @days
			WHERE [id] = @id
End



Create procedure [dbo].[DeleteRecurenceType](  
   @id int  
)  
as   
begin  
   DELETE FROM recurenceType where id=@id 
End


Create Procedure [dbo].[GetRecurenceTypes]  
as  
begin  
   select * from recurenceType
End


/*=====================================*/

Create procedure [dbo].[AddExpenseCategoryType](
	@detail varchar(500),
	@priority int
)  
as
begin
	Insert into expenseCategory values(
		@detail,
		@priority
	)
End

Create procedure [dbo].[UpdateexpenseCategory](  
	@id int,
	@detail varchar(500),
	@priority int
) 
as  
begin  
	UPDATE [expenseCategory]   
		SET
		[detail] = @detail,
		[priority] = @priority
			WHERE [id] = @id
End


Create procedure [dbo].[DeleteexpenseCategory](  
   @id int  
)  
as   
begin  
   DELETE FROM expenseCategory where id=@id 
End


Create Procedure [dbo].[GetexpenseCategorys]  
as  
begin  
   select * from expenseCategory
End



/*============incomeRecord=================*/

Create procedure [dbo].[AddIncomeRecord](
	@idUser int,
	@detail varchar(500),
	@amount float,
	@paymentDate date
)  
as
begin
	Insert into incomeRecord values(
		@idUser,
		@detail,
		@amount,
		@paymentDate
	)
End;



Create procedure [dbo].[UpdateIncomeRecord](  
	@id int,
	@detail varchar(500),
	@amount float,
	@paymentDate date
) 
as  
begin  
	UPDATE [incomeRecord]   
		SET
		[detail] = @detail,
		[amount] = @amount,
		[paymentDate] = @paymentDate
			WHERE [id] = @id
End;



Create procedure [dbo].[DeleteIncomeRecord](  
   @id int  
)  
as   
begin  
   DELETE FROM incomeRecord where id=@id 
End;


CREATE or ALTER Procedure [dbo].[GetIncomeRecords](
	@idUser int
)
AS  
BEGIN  
	SELECT detail,
			amount,
			paymentDate
		FROM incomeRecord
			WHERE ir.idUser = @idUser
END;





/*=====================paymentRecord=====================*/

Create or alter procedure [dbo].[AddPaymentRecord](
	@idUser int,
	@detail varchar(500),
	@amount float,
	@recurrence int,
	@recurrenciaTypeId int,
	@paymentDate date,
	@providerId int,
	@expenseCategoryId int
)  
as
begin
	Insert into paymentRecord values(
		@idUser,
		@detail,
		@amount,
		@recurrence,
		@recurrenciaTypeId,
		@paymentDate,
		@providerId,
		@expenseCategoryId
	)
End;



Create procedure [dbo].[UpdatePaymentRecord](  
	@id int,
	@detail varchar(500),
	@amount float,
	@recurrence int,
	@recurrenciaTypeId int,
	@paymentDate date,
	@providerId int,
	@expenseCategoryId int
) 
as  
begin  
	UPDATE [paymentRecord]   
		SET
		[detail] = @detail,
		[amount] = @amount,
		[recurrence] = @recurrence,
		[recurrenciaTypeId] = @recurrenciaTypeId,
		[paymentDate] = @paymentDate,
		[providerId] = @providerId,
		[expenseCategoryId] = @expenseCategoryId
			WHERE [id] = @id
End;



Create procedure [dbo].[DeletePaymentRecord](  
   @id int
)  
as   
begin  
   DELETE FROM paymentRecord where id=@id 
End;


Create Procedure [dbo].[GetPaymentRecords](
	@idUser int
)
as  
begin  
   select * from paymentRecord WHERE idUser = @idUser
End;




/*============Alerts============*/
	
CREATE OR ALTER Procedure [dbo].[GetAlerts]  

AS  
BEGIN  
	SELECT p.paymentDate
		,p.id
		,p.detail
		,p.amount
		, rt.days
		,DATEADD(day, rt.days, p.paymentDate) AS sumaryDate
	FROM [dbo].[paymentRecord] p
		INNER JOIN [dbo].[recurenceType] rt 
		ON p.recurrenciaTypeId = rt.id
		WHERE p.recurrence = 1;
END;


/*==============GetPaymentCurrentMonth==========*/
CREATE OR ALTER Procedure [dbo].[GetPaymentCurrentMonth]  
	@montLess int
AS  
BEGIN  
	SELECT  SUM(p.amount) AS sumamount
	FROM [dbo].[paymentRecord] p
	WHERE DATEPART(month, p.paymentDate) = MONTH(getdate()) - @montLess
END;



/*==============GetIncomentByMonth==========*/
CREATE OR ALTER Procedure [dbo].[GetIncomentByMonth]  
	@montLess int
AS  
BEGIN 
	SELECT  SUM(i.amount) AS sumamount
	FROM [dbo].[incomeRecord] i
	WHERE DATEPART(month, i.paymentDate) = MONTH(getdate()) - @montLess
END;



/*==================GetPaymentByExpenseCategoryCurrentMonth================*/
CREATE OR ALTER Procedure [dbo].[GetPaymentByExpenseCategoryCurrentMonth]
AS  
BEGIN  
	SELECT 
		ec.detail
		,SUM(p.amount) AS sumamount
		
	FROM [dbo].[paymentRecord] p
	INNER JOIN expenseCategory ec
		ON p.expenseCategoryId = ec.id
	WHERE DATEPART(month, p.paymentDate) = MONTH(getdate())
	GROUP BY ec.detail
END;


/*==================GetFutureProjectionsPay by Month================*/
CREATE OR ALTER Procedure [dbo].[GetFutureProjectionsPay]
AS  
BEGIN  
	SELECT 
		SUM(CAST(p.amount/rt.days AS float)*30) AS payMonth
	FROM [dbo].[paymentRecord] p
	INNER JOIN [dbo].[recurenceType] rt
		ON p.recurrenciaTypeId = rt.id
	WHERE DATEPART(month, p.paymentDate) = MONTH(getdate())
	AND p.recurrence = 1
END;


/*============GetFutureProjectionsIncoment===========*/
CREATE OR ALTER Procedure [dbo].[GetFutureProjectionsIncoment]
AS  
BEGIN  
	SELECT 
		SUM(i.amount) AS incomentMonth
	FROM [dbo].[incomeRecord] i
	WHERE DATEPART(month, i.paymentDate) = MONTH(getdate())
END;


/*============GetFutureProjectionsSaving===========*/
CREATE OR ALTER Procedure [dbo].[GetFutureProjectionsSaving]
AS  
BEGIN  
	SELECT 
		SUM(CAST(p.amount/rt.days AS float)*30) AS payMonth
	FROM [dbo].[paymentRecord] p
	INNER JOIN [dbo].[recurenceType] rt
		ON p.recurrenciaTypeId = rt.id
	INNER JOIN [dbo].[expenseCategory] ec
		ON p.expenseCategoryId = ec.id

	WHERE DATEPART(month, p.paymentDate) = MONTH(getdate())
	AND p.recurrence = 1
	AND ec.priority = 1
END;