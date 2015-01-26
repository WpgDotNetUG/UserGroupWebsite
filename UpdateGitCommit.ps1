$webConfig = "$env:DEPLOYMENT_TARGET\Web.config"

$doc = (Get-Content $webConfig) -as [Xml]

$node = $doc.configuration.appSettings.add | where Key -EQ "appharbor.commit_id"

$node.Value = $env:SVC_COMMIT_ID

$doc.Save($webConfig)