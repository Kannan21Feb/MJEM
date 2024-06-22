SELECT ' ALTER TABLE ' + parent_tables.name+' DROP CONSTRAINT ' + fk.name
FROM
    sys.foreign_keys fk
INNER JOIN 
    sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id
INNER JOIN 
    sys.tables parent_tables ON fk.parent_object_id = parent_tables.object_id
INNER JOIN 
    sys.columns parent_columns ON fkc.parent_object_id = parent_columns.object_id AND fkc.parent_column_id = parent_columns.column_id
INNER JOIN
    sys.tables referenced_tables ON fk.referenced_object_id = referenced_tables.object_id
INNER JOIN 
    sys.columns referenced_columns ON fkc.referenced_object_id = referenced_columns.object_id AND fkc.referenced_column_id = referenced_columns.column_id

	----------------------------------------------------------------------------
	SELECT
    'DROP ' + CASE WHEN  type = 'U' THEN 'TABLE '
                   WHEN  type = 'P' THEN 'PROCEDURE '
                   WHEN  type = 'FN'THEN 'FUNCTION '
                   WHEN  type = 'V'THEN 'VIEW ' END
     + QUOTENAME(s.[name]) + '.' + QUOTENAME(o.[name]) + CHAR(10) + 'GO' + CHAR(10)

FROM        master.sys.objects o 
INNER JOIN  master.sys.schemas s ON o.[schema_id] = s.[schema_id]
WHERE o.[is_ms_shipped] <> 1
  AND o.[type] IN ('U')


