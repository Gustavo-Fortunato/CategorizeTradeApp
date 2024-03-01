 -- Create Trade table 
CREATE TABLE Trade (
    TradeID INT PRIMARY KEY,
    Value FLOAT,
    ClientSector NVARCHAR(50)
);

-- Insert sample trades into Trade table
INSERT INTO Trade (TradeID, Value, ClientSector) VALUES
    (1, 2000000, 'Private'),
    (2, 400000, 'Public'),
    (3, 500000, 'Public'),
    (4, 3000000, 'Public');

-- Create TradeCategory table to store the output categories
CREATE TABLE TradeCategory (
    TradeID INT,
    Category NVARCHAR(50)
);

-- Create stored procedure 
CREATE PROCEDURE CategorizeTrades
AS
BEGIN
    -- Populate TradeCategory table based on categorization rules
    INSERT INTO TradeCategory (TradeID, Category)
    SELECT
        TradeID,
        CASE
            WHEN Value < 1000000 AND ClientSector = 'Public' THEN 'LOWRISK'
            WHEN Value >= 1000000 AND ClientSector = 'Public' THEN 'MEDIUMRISK'
            WHEN Value >= 1000000 AND ClientSector = 'Private' THEN 'HIGHRISK'
            ELSE 'UNDEFINED'
        END AS Category
    FROM Trade;
END;

-- Execute the stored procedure
EXEC CategorizeTrades;