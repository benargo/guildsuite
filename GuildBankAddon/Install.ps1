<##
 # Install Script for guild bank addon.
 #
 # This script takes the files required for the guild bank addon and installs them to the user's World of Warcraft addons directory.
 #
 # Authors:
 # - Ben Argo <@benargo>
 #>

<#
 # Get-Folder Function
 #
 # This function prompts the user for their World of Warcraft addons folder.
 #>
Function Get-WoWDir($initialDirectory)
{
    [System.Reflection.Assembly]::LoadWithPartialName("System.windows.forms")|Out-Null

    $foldername = New-Object System.Windows.Forms.FolderBrowserDialog
    $foldername.Description = "Select your WoW Classic 'Addons' folder."
    $foldername.RootFolder = "MyComputer"
    $foldername.SelectedPath = -join([Environment]::GetFolderPath('ProgramFilesX86'), "\World of Warcraft\_classic_\Interface\Addons")

    if($foldername.ShowDialog() -eq "OK")
    {
        $folder += $foldername.SelectedPath
    }
    return $folder
}

# Say hello!
echo "Hello. Welcome to the installer script for the Guild Bank addon."

# Prompt the user for their 'Addons' directory...
echo "Please select your WoW Classic 'Addons' folder."
$wowdir = Get-WoWDir
echo "Addons folder set to '$wowdir'."

# Create the 'GuildBank' folder in $wowdir, if it doesn't already exist...
New-Item -Path $wowdir -Name "GuildBank" -ItemType "directory"

# Copy all the files from ./src to $wowdir/GuildBank...
Copy-Item -Path "$PSScriptRoot\"

# End script...
echo "`nInstall complete. Press any key to [Exit]..."
$x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyUp")
If ($x.VirtualKeyCode -eq '0') {
    Exit
}
