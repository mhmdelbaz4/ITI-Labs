<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:template match="/">
		<html>
			<head>
				<title>Data For Catalogs</title>
			</head>
			<body>
			<table width="200" align="center" border="1">
					<thead>
						<tr>
							<th>TITLE</th>
							<th>ARTIST</th>
						</tr>
					</thead>
					<tbody style="text-align:center">
						<xsl:for-each select="//CD">
						<xsl:sort select="PRICE" data-type="number"  order="descending"/>
							<xsl:choose>
								<xsl:when test="PRICE &gt; 10">
									<tr style="background-color:red;color:white" >
										<td><xsl:value-of select="TITLE"/></td>
										<td><xsl:value-of select="ARTIST"/></td>
									</tr>
								</xsl:when>
								<xsl:otherwise>
								<tr style="background-color:green;color:white" >
										<td><xsl:value-of select="TITLE"/></td>
										<td><xsl:value-of select="ARTIST"/></td>
								</tr>
								</xsl:otherwise>
							</xsl:choose>
						</xsl:for-each>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
