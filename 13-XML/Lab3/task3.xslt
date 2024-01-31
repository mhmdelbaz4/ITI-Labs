<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:template match="/xslTutorial">
		<html>
			<body>
				<span>
					<xsl:for-each select="number">		
						<xsl:choose>
							<xsl:when test="position() = last()">
								<xsl:value-of select="." /> = 
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="." /> + 				
							</xsl:otherwise>
						</xsl:choose>
					</xsl:for-each>	
					<xsl:value-of select="sum(number)" />			
				</span>
			</body>		
		</html>
	</xsl:template>
</xsl:stylesheet>
