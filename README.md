# InfluxDB Line Protocol to JSON Converter For .Net and .NetCore
This library is useful for decoding `InfluxDB Line Protocol` to a `JSON` string.
The InfluxDB Line Protocol is as follow:
```
<measurement>[,<tag_key>=<tag_value>[,<tag_key>=<tag_value>]] <field_key>=<field_value>[,<field_key>=<field_value>] [<timestamp>] 
```    
for more information refer to [InfluxDB Line Protocol documentation](https://docs.influxdata.com/influxdb/v1.6/write_protocols/line_protocol_reference)
