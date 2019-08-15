import 'dart:async';
import 'package:aqueduct/aqueduct.dart';

class Migration3 extends Migration {
  @override
  Future upgrade() async {
    database.createTable(SchemaTable("_Text", [
      SchemaColumn("id", ManagedPropertyType.bigInteger,
          isPrimaryKey: true,
          autoincrement: true,
          isIndexed: false,
          isNullable: false,
          isUnique: false),
      SchemaColumn("name", ManagedPropertyType.string,
          isPrimaryKey: false,
          autoincrement: false,
          isIndexed: false,
          isNullable: false,
          isUnique: true),
      SchemaColumn("value", ManagedPropertyType.string,
          isPrimaryKey: false,
          autoincrement: false,
          isIndexed: false,
          isNullable: false,
          isUnique: false)
    ]));
    database.deleteTable("_Hero");
  }

  @override
  Future downgrade() async {}

  @override
  Future seed() async {}
}
