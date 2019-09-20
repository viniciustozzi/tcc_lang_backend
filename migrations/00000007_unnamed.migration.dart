import 'dart:async';
import 'package:aqueduct/aqueduct.dart';   

class Migration7 extends Migration { 
  @override
  Future upgrade() async {
   		database.addColumn("_WordSection", SchemaColumn("word", ManagedPropertyType.string, isPrimaryKey: false, autoincrement: false, isIndexed: false, isNullable: false, isUnique: false));
		database.addColumn("_WordSection", SchemaColumn("isPressed", ManagedPropertyType.boolean, isPrimaryKey: false, autoincrement: false, isIndexed: false, isNullable: false, isUnique: false));
  }
  
  @override
  Future downgrade() async {}
  
  @override
  Future seed() async {}
}
    