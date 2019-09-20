import 'dart:async';
import 'package:aqueduct/aqueduct.dart';   

class Migration6 extends Migration { 
  @override
  Future upgrade() async {
   		database.createTable(SchemaTable("_WordSection", [SchemaColumn("id", ManagedPropertyType.bigInteger, isPrimaryKey: true, autoincrement: true, isIndexed: false, isNullable: false, isUnique: false)]));
		database.addColumn("_WordSection", SchemaColumn.relationship("text", ManagedPropertyType.bigInteger, relatedTableName: "_Text", relatedColumnName: "id", rule: DeleteRule.nullify, isNullable: true, isUnique: false));
		database.addColumn("_Text", SchemaColumn("title", ManagedPropertyType.string, isPrimaryKey: false, autoincrement: false, isIndexed: false, isNullable: false, isUnique: true));
		database.deleteColumn("_Text", "name");
		database.deleteColumn("_Text", "value");
  }
  
  @override
  Future downgrade() async {}
  
  @override
  Future seed() async {}
}
    