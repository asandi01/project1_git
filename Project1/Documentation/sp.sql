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

Create procedure [dbo].[AddNewProvider](
	@detail varchar(500)
)  
as
begin
	Insert into provider values(
		@detail
	)
End


Create procedure [dbo].[UpdateProvider](  
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


Create procedure [dbo].[AddNewRecurenceType](
	@detail varchar(500)
)  
as
begin
	Insert into recurenceType values(
		@detail
	)
End



Create procedure [dbo].[UpdateRecurenceType](  
	@id int,
	@detail varchar(500)
) 
as  
begin  
	UPDATE [recurenceType]   
		SET
		[detail] = @detail
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
