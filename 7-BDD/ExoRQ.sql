--1 Retrouver le prénom et l'adresse email du client qui a pour nom de compagnie, 'Bike World'
Select FirstName,EmailAddress from SalesLT.Customer
where CompanyName = 'Bike World'
--2 Retrouver les noms de compagnies qui ont pour ville 'Dallas'
select CompanyName from SalesLT.Customer join
SalesLT.Address on CustomerID = CustomerID
where City='Dallas'
--3 Combien de produits avec un prix > 1000$ ont été vendues
Select count(SalesLT.SalesOrderDetail.ProductID) from SalesLT.SalesOrderDetail join
SalesLT.Product on SalesLT.Product.ProductID= SalesLT.SalesOrderDetail.ProductID
where UnitPrice>'1000'
--4 Retrouver les companies dont les clients ont commandés pour plus de 10.000$ (en incluant le sous-total, les taxes et les frais de transport)
Select CompanyName from SalesLT.Customer as C
inner join SalesLT.SalesOrderHeader as S on S.CustomerID=C.CustomerID
where TotalDue > 10000
--5 Retrouver le nombre de chaussettes de courses, commandées par la société 'Riding Cycles'
Select Sum(OrderQty) from SalesLT.SalesOrderDetail as S
join SalesLT.SalesOrderHeader as SOH on SOH.SalesOrderID = S.SalesOrderID
join SalesLT.Customer as C on C.CustomerID = SOH.CustomerID
join SalesLT.Product as P on P.ProductID=S.ProductID where
P.Name like '%socks%' and C.CompanyName = 'Riding Cycles'
--6 Une « commande d'article unique » est une commande client pour laquelle un seul article est commandé. Affichez le SalesOrderID et le UnitPrice pour chaque commande d'article unique.
Select SalesOrderID, UnitPrice From SalesLT.SalesOrderDetail 
where OrderQty=1
--7 Retrouvez le nom du produit et le nom de la compagnie pour les clients ayant commandés le produit 'Racing Socks'
Select CompanyName from SalesLT.Customer as C 
join SalesLT.Product as P on Name = 'Racing Socks'
join SalesLT.SalesOrderHeader as OH on OH.CustomerID=c.CustomerID 
join SalesLT.SalesOrderDetail as OD on OD.SalesOrderID = OH.SalesOrderID
where P.ProductID = OD.ProductID
--8 Retrouver la description du produit avec l'identifiant 736 pour la langue française.
select Description from SalesLT.ProductDescription as PD
join SalesLT.ProductModelProductDescription as PMPD 
on PMPD.ProductDescriptionID=PD.ProductDescriptionID and PMPD.Culture = 'fr'
join SalesLT.Product as P on P.ProductModelID = PMPD.ProductModelID
where P.ProductID = 736
--9tocheck En utilisant le SubTotal value dans SaleOrderHeader, lister les commandes de la plus petite à la plus grande. Pour chaque commande, listez le nom de la compagnie, le sous total et le poids total de la commande
Select CompanyName, SOH.SubTotal, P.Weight From SalesLT.Customer as C
join SalesLT.SalesOrderHeader as SOH on SOH.CustomerID = C.CustomerID
join SalesLT.SalesOrderDetail as SOD on SOD.SalesOrderID = SOH.SalesOrderID
join SalesLT.Product as P on P.ProductID = SOD.ProductID
group by CompanyName, SOH.SubTotal,P.Weight
order by SubTotal desc
--10tochk Retrouver combien de produits avec la catégorie 'Cranksets' ont été vendues à une adresse à Londres.
select count(*)from SalesLT.SalesOrderDetail as SOD
join SalesLT.SalesOrderHeader as SOH on SOH.SalesOrderID = SOD.SalesOrderID
join SalesLT.Address A on A.AddressID = SOH.ShipToAddressID
join SalesLT.Product as P on SOD.ProductID = P.ProductID
join SalesLT.ProductCategory as PC on PC.ProductCategoryID = P.ProductCategoryID
where PC.Name = 'Cranksets' and A.City='London'
--11 Pour chaque client avec un 'Main Office' à Dallas, retrouvez la première ligne de l'adresse de livraison. Si aucune adresse n'existe, laissez là vide. N'ayez qu'une seule ligne par client.
select C.LastName,AddressLine1 from SalesLT.CustomerAddress as CA
join SalesLT.Address as A on A.AddressID = CA.AddressID
join SalesLT.Customer as C on C.CustomerID = CA.CustomerID
where A.City = 'Dallas'
--12 Pour chaque vente, retrouvez le SalesOrderID et le sous-total, calculé à partir des 3 façons suivantes : depuis le SalesOrderHeader, la somme des OrderQtyUnitPrice et la somme des OrderQtyListPrice
--a
select SOH.SalesOrderID,SOH.SubTotal from SalesLT.SalesOrderHeader as SOH
join SalesLT.SalesOrderDetail as SOD on SOD.SalesOrderID = SOH.SalesOrderID
--btodo
select sum(SOD.LineTotal) as SubTotal,SOH.SalesOrderID from SalesLT.SalesOrderHeader as SOH
join SalesLT.SalesOrderDetail as SOD on SOD.SalesOrderID = SOH.SalesOrderID
group by SOH.SalesOrderID
--c

--13 Retrouvez l'article le plus vendu, par valeur.
select P.Name as ProductName,max(SOD.OrderQty) as Qty From SalesLT.SalesOrderDetail as SOD
join SalesLT.Product as P on SOD.ProductID = P.ProductID 
where SOD.OrderQty = (select max(OrderQty) from SalesLT.SalesOrderDetail)
group by P.Name
order by Qty desc

--14 Retrouvez combien de commandes sont dans les intervals suivants : 0-99, 100-999, 1000-9999, 10000

--15 Retrouvez les trois villes les plus importantes. Affichez la répartition de la catégorie de produits de premier niveau par rapport à chaque ville.
select A.City,SOH.SubTotal from SalesLT.Address as A
join SalesLT.SalesOrderHeader as SOH on SOH.BillToAddressID = A.AddressID
join SalesLT.SalesOrderDetail as SOD on SOD.SalesOrderDetailID = SOH.SalesOrderID
where SOH.SubTotal > (select avg(SalesLT.SalesOrderHeader.SubTotal)from SalesLT.SalesOrderHeader)
order by SOH.SubTotal, A.City