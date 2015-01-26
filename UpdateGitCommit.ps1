Write-Output "DEPLOYMENT_TARGET: '$env:DEPLOYMENT_TARGET'"

Write-Output "SVC_COMMIT_ID: '$env:SVC_COMMIT_ID'"


$webConfig = "$env:DEPLOYMENT_TARGET\Web.config"

$doc = (Get-Content $webConfig) -as [Xml]

$node = $doc.configuration.appSettings.add | where Key -EQ "appharbor.commit_id"

$node.Value = $env:SVC_COMMIT_ID

$doc.Save($webConfig)

Write-Output "Completed App setting update"