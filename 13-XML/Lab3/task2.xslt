<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:template match="/xslTutorial">
			<html>
				<head>
					<title></title>
				</head>
				<body style="text-align:center;">
						<table border="1" width="150">
							<tbody>
								<xsl:for-each select="word">
								<xsl:sort select="@id" data-type="text"  order="ascending" case-order="lower-first"/>
								<tr style="text-align:center;">
									<td><xsl:value-of select="@id"/></td>
								</tr>
								</xsl:for-each>
							</tbody>						
						</table>
				</body>			
			</html>
	</xsl:template>
</xsl:stylesheet>