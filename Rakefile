$input = "asd"
$target = "asd"
$target_pdf = "#{$target}.pdf"
$bib = "bibtex"
$tex = "pdflatex"

task :default => $target_pdf

def inputs()
  FileList["**/*.tex", "**/*.bib", "**/*.png", "**/*.PNG"]
end

file $target_pdf => inputs do
  sh "#{$tex} -jobname=#{$target} #{$input}"
  sh "#{$bib} #{$input}"
  sh "#{$tex} -jobname=#{$target} #{$input}"
  sh "#{$tex} -jobname=#{$target} #{$input}"
end

task :clean do
  generated_files = FileList["*"].select{|f| File.file?(f)} - inputs() - [File.basename(__FILE__), "README.md"] - FileList["*.tcp"]
  generated_files.each{|f| File.delete(f)}
end

