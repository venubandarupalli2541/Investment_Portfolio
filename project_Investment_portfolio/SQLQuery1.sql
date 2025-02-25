CREATE TABLE Report ( 
 reportId INT IDENTITY(1,1) PRIMARY KEY, 
 reportType VARCHAR(50) CHECK (reportType IN ('Portfolio', 'Risk', 'Asset')), 
 generatedDate DATE 
);

