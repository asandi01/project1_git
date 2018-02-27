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