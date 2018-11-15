<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html>
<body>
<h4>订单</h4>
<table>
    <tr>
      <th align ="left">订单号</th>
      <th align ="left">流水号</th>
      <th align ="left">商品名称</th>
      <th align ="left">客户名称</th>
      <th align ="left">商品金额</th>
      <th align ="left">客户电话</th>
      <th align ="left">商品日期</th>
    </tr>
    <xsl:for-each select="Order/orderList/OrderDetails">
    	<tr>
	<td><xsl:value-of select="orderNumber"/></td>
	<td><xsl:value-of select="orderBehindNum"/></td>
	<td><xsl:value-of select="orderName"/></td>
	<td><xsl:value-of select="orderOwner"/></td>
	<td><xsl:value-of select="orderMoney"/></td>
	<td><xsl:value-of select="phoneNumber"/></td>
	<td><xsl:value-of select="orderDate"/></td>
	</tr>
    </xsl:for-each>
</table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>
