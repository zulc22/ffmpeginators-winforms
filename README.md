*Using this software requires you or a freinds' knowledge of FFmpeg to use.*

[Releases page](https://github.com/zulc22/ffmpeginators-winforms/releases)

# Infomercial Pitch

Have you ever had to convert audio, video, or image files in a way that could so obviously be automated?

Do you catch yourself writing shell scripts to loop through a ton of files just to convert them with FFmpeg?

Hi, I'm Sadie Zulc, and FFmpeginator is the !!REVOLUTIONARY SOLUTION!! to YOUR problem.

# How do I use it?

Simply run the Preset Manager, and create the presets to satisfy your needs with the power of a metric ton of FFmpeg arguments.

As soon as you've pressed 'OK', your preset will now be visible in the File Explorer's `Send To` menu!

You can now right click on a file, or even multiple files, go to `Send To`, and select your preset,
to run that one preset on them all.

Take for example, this FFmpeg command: `ffmpeg -i video.mp4 -c:v h264 -c:a aac -pix_fmt yuv420p -y video.yuv420p.mp4`

A command like this is very useful to re-encode files for picky-eating websites that just won't accept half the videos
you throw at it.

You can convert this into an FFmpeginator preset right now, so you never have to type that paragraphs-worth of
command line arguments again!

Open the Preset Manager, click on "New...", enter a preset name, set the extension to "`yuv420p.mp4`", and set the
arguments to "`-c:v h264 -c:a aac -pix_fmt yuv420p -y`".

This will effectively construct the exact same command, but the input file is replaced with whatever you select in your
file manager.

There is also a CLI available, run the command `FFmpeginatorCLI` to see the available options. Anything that can be done
through Preset Manager is also available there, as well as the actual preset execution.