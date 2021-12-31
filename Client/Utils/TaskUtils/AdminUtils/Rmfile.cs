﻿using Client.Models;

using static Client.Models.Client;

namespace Client.Utils.TaskUtils.AdminUtils
{
    class Rmfile : Models.AdminTask
    {
        private string targetDir { get; set; }
        public override string TaskName => "RmFile";

        public override string Desc => "Removes a file";

        public override string AdminUtilExec(string[] opts)
        {
            try
            {

                if (opts is null) { throw new AtlasException($"[*] Usage: RmDir [targetDir]\n"); }
                if (!(opts.Length == 2)) { throw new AtlasException($"[*] Usage: RmDir [targetDir]\n"); }
                if (CurrentImplant is null) { throw new AtlasException("[-] No connected implant"); }

                targetDir = opts[1];

                return TaskOps.sendAdminUtil(TaskName, targetDir);
            }
            catch (AtlasException e) { return e.Message; }
        }
    }
}
