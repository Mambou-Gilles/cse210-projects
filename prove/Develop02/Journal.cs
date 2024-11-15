public class Journal {
    public List<Entry> _entries = new List<Entry>();


    public void AddEntry(Entry newEntry){
        _entries.Add(newEntry);
        Console.WriteLine("\n Entry added");
    }
    public void DisplayAll(){

        if (_entries.Count == 0){
            Console.WriteLine("\n Your journal is empty.");
            return;
        }

        Console.WriteLine("Your Journal Entries:");

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"\nEntry {i + 1}:");
            _entries[i].Display();
        }
        
        // foreach (Entry entry in _entries){
        //     entry.Display();
        // }

    }

    public void SaveToFile(string filename){
        using (StreamWriter writer = new StreamWriter(filename)){
            foreach (Entry entry in _entries){
                writer.WriteLine(entry.ToFileString());
            }
            Console.WriteLine("\n Journal Saved");
        }
    }

    public void LoadFromFile(string filename){
        if(File.Exists(filename)){
            _entries.Clear();
            using (StreamReader reader = new StreamReader(filename)){
                string line;
                while ((line = reader.ReadLine()) != null){
                    _entries.Add(Entry.FromFileString(line));
                }
                Console.WriteLine($"\n You have loaded {filename}.");
            }
        } else {
            Console.WriteLine("\n File not found");
        }
    }

    public void DeleteEntry(int index)
    {
        if (index < 0 || index >= _entries.Count)
        {
            Console.WriteLine("\nInvalid entry number.");
            return;
        }
        _entries.RemoveAt(index);
        Console.WriteLine("\nEntry deleted.");
    }

    public void ClearJournal()
    {
        _entries.Clear();
        Console.WriteLine("\nAll entries have been deleted.");
    }

}