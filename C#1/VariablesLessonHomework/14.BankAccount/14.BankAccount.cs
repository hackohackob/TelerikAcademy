using System;

//A bank account has a holder name(first name, middle name, last name),avaliable amount, bank name, IBAN, BIC code and 3 credit card numbers
//Declare the variables needed to keep the information for a single account
class BankAccount
{
    static void Main()
    {
        string firstName = "Hacko", middleName = "HackoB", lastName = "HackoB";
        double amount = 1678.78;
        string bankName = "DSK Bank";
        string IBAN = "12345678901", BIC = "123456";                                            //2nd way: ulong IBAN = "12345678901", BIC = "123456";
        string creditCard1 = "123456789", creditCard2 = "666666666", creditCard3 = "555555555"; //2nd way: ulong creditCard1 = "123456789", creditCard2 = "66666666666",
                                                                                                //               creditCard3 = "555555555";

        //There is no need for the IBAN, BIC and credit card numbers to be saved in "ulong" type variables, because that way they will take a lot of memory and they are not
        //needed to be used like numbers. They are used only as symbols.
        Console.WriteLine("Bank Account: \nName:{0} {1} {2} \nAmount: {3} \nBank: {4} \nIBAN: {5} \nBIC: {6} \nCredit Card Numbers: {7} {8} {9}"
            ,firstName,middleName,lastName,amount,bankName,IBAN,BIC,creditCard1,creditCard2,creditCard3);
    }
}

